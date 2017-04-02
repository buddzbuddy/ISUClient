using Domain;
using Domain.Filters;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Logic
{
    public abstract class XRepository
    {
        protected XContext context;
        public XRepository()
        {
            context = new XContext();
        }
        public void UpdateSource(XDocument doc)
        {
            context.UpdateSource(doc);
        }
        public T ParseTo<T>(XElement xObj, bool fromAttribute = false) where T : class
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            bool isNew = false;
            var isNewAttribute = xObj.Attribute(DBConfigInfo.IsNew);
            if (isNewAttribute != null)
                Boolean.TryParse(isNewAttribute.Value, out isNew);

            bool isDeleted = false;
            var isDeletedAttribute = xObj.Attribute(DBConfigInfo.IsDeleted);
            if (isDeletedAttribute != null)
                Boolean.TryParse(isDeletedAttribute.Value, out isDeleted);

            bool isModified = false;
            var isModifiedAttribute = xObj.Attribute(DBConfigInfo.IsModified);
            if (isModifiedAttribute != null)
                Boolean.TryParse(isModifiedAttribute.Value, out isModified);

            foreach (var property in obj.GetType().GetProperties())
            {
                //custom skips
                if (property.IsDefined(typeof(SkipAttribute), false)) continue;
                try
                {
                    string xValue = "";
                    if(fromAttribute)
                    {
                        var xAttribute = xObj.Attribute(property.Name);
                        if (xAttribute != null)
                            xValue = xAttribute.Value;
                    }
                    else
                    {
                        var xElement = xObj.Element(property.Name);
                        if (xElement != null)
                            xValue = xElement.Value;
                    }

                    if (new[] { typeof(Guid), typeof(Nullable<Guid>) }.Contains(property.PropertyType))
                    {
                        Guid val;
                        if (Guid.TryParse(xValue, out val))
                            property.SetValue(obj, val, null);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(obj, DateTime.Parse(xValue), null);
                    }
                    else if (new[] { typeof(Int32), typeof(Nullable<Int32>) }.Contains(property.PropertyType))
                    {
                        int val;
                        if (int.TryParse(xValue, out val))
                            property.SetValue(obj, val, null);
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        if (property.Name == DBConfigInfo.IsNew)
                        {
                            property.SetValue(obj, isNew, null);
                        }
                        else if (property.Name == DBConfigInfo.IsDeleted)
                        {
                            property.SetValue(obj, isDeleted, null);
                        }
                        else if (property.Name == DBConfigInfo.IsModified)
                        {
                            property.SetValue(obj, isModified, null);
                        }
                        else
                        {
                            bool val = false;
                            if (Boolean.TryParse(xValue, out val))
                                property.SetValue(obj, val, null);
                            else
                                property.SetValue(obj, val, null);
                        }
                    }
                    else if (property.PropertyType == typeof(Decimal))
                    {
                        property.SetValue(obj, Decimal.Parse(xValue), null);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        property.SetValue(obj, Double.Parse(xValue), null);
                    }
                    else if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(obj, xValue, null);
                    }
                    else if (property.PropertyType == typeof(Nullable<DateTime>))
                    {
                        if (!string.IsNullOrEmpty(xValue))
                            property.SetValue(obj, DateTime.Parse(xValue), null);
                    }
                    else if (property.PropertyType == typeof(Nullable<double>))
                    {
                        if (!string.IsNullOrEmpty(xValue))
                            property.SetValue(obj, double.Parse(xValue), null);
                    }
                    else if (property.PropertyType == typeof(Nullable<decimal>))
                    {
                        if (!string.IsNullOrEmpty(xValue))
                            property.SetValue(obj, decimal.Parse(xValue), null);
                    }
                    else
                        throw new ApplicationException("Не могу преобразовать XElement, тип поля \"" + property.PropertyType.FullName + "\" не определен!");
                }
                catch (Exception e)
                {
                    while (e.InnerException != null) e = e.InnerException;
                    throw new InvalidOperationException("Ошибка при преобразовании XElement в свойство сущности \"" + typeof(T).Name + " -> " + property.Name + "\". Описание: " + e.Message);
                }
            }
            return obj;
        }

        public IEnumerable<T> ParseList<T>(IEnumerable<XElement> xList, bool fromAttribute = false) where T : class
        {
            return from xObj in xList
                   where (xObj.Attribute(DBConfigInfo.IsDeleted) != null ? (!bool.Parse(xObj.Attribute(DBConfigInfo.IsDeleted).Value)) : true)
                   select ParseTo<T>(xObj, fromAttribute);
        }

        public XElement WrapFrom<T>(T obj) where T : class
        {
            var xObj = new XElement(typeof(T).Name);
            foreach (var property in obj.GetType().GetProperties())
            {
                //custom skips
                if (property.IsDefined(typeof(SkipAttribute), false)) continue;

                if ((property.PropertyType == typeof(bool) && property.Name == DBConfigInfo.IsNew)
                    || (property.PropertyType == typeof(bool) && property.Name == DBConfigInfo.IsDeleted)
                    || (property.PropertyType == typeof(bool) && property.Name == DBConfigInfo.IsModified))
                {
                    xObj.SetAttributeValue(property.Name, property.GetValue(obj, null));
                }
                else
                {
                    var xProperty = new XElement(property.Name);
                    var val = property.GetValue(obj, null);
                    if (val != null)
                        xProperty.SetValue(val);
                    xObj.Add(xProperty);
                }
            }
            return xObj;
        }


        public T Get<T>(Guid Id) where T : class
        {
            var xObj = context.GetElements(typeof(T).Name + "s").FirstOrDefault(x => Guid.Parse(x.Element("Id").Value) == Id);
            if (xObj != null)
                return ParseTo<T>(xObj);
            return default(T);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var xList = context.GetElements(typeof(T).Name + "s");
            if (xList != null && xList.Count() > 0)
                return ParseList<T>(xList);
            return null;
        }

        public void Save<T>(T obj, bool isUpdated = false) where T : class
        {
            if (!isUpdated)
                context.AddElement(WrapFrom(obj), typeof(T).Name + "s");
            else
            {
                context.UpdateElement(WrapFrom(obj), typeof(T).Name + "s");
            }
        }

        public void Delete<T>(Guid Id) where T : class
        {
            if (Get<T>(Id) != null)
            {
                context.DeleteElement(typeof(T).Name + "s", Id);
            }
            else
                throw new ApplicationException("Не могу удалить запись \"" + typeof(T).Name + "\" Запись не найдена. Id \"" + Id + "\"");
        }
    }
}
