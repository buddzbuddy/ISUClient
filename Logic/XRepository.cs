using Domain;
using Domain.Filters;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public T ParseTo<T>(XElement xObj, bool fromAttribute = false)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            bool isNew = false;
            var isNewAttribute = xObj.Attribute(DBConfigInfo.IsNewKeyPropertyName);
            if (isNewAttribute != null)
                Boolean.TryParse(isNewAttribute.Value, out isNew);

            bool isDeleted = false;
            var isDeletedAttribute = xObj.Attribute(DBConfigInfo.IsDeletedKeyPropertyName);
            if (isDeletedAttribute != null)
                Boolean.TryParse(isDeletedAttribute.Value, out isDeleted);

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

                    if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(obj, Guid.Parse(xValue));
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(obj, DateTime.Parse(xValue));
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        property.SetValue(obj, Int32.Parse(xValue));
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        if (property.Name == DBConfigInfo.IsNewKeyPropertyName)
                        {
                            property.SetValue(obj, isNew);
                        }
                        else if (property.Name == DBConfigInfo.IsDeletedKeyPropertyName)
                        {
                            property.SetValue(obj, isDeleted);
                        }
                        else
                        {
                            bool val = false;
                            if (Boolean.TryParse(xValue, out val))
                                property.SetValue(obj, val);
                            else
                                property.SetValue(obj, val);
                        }
                    }
                    else if (property.PropertyType == typeof(Decimal))
                    {
                        property.SetValue(obj, Decimal.Parse(xValue));
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        property.SetValue(obj, Double.Parse(xValue));
                    }
                    else if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(obj, xValue);
                    }
                    else if (property.PropertyType == typeof(List<>))
                    {
                        continue;
                    }
                    else if (property.PropertyType == typeof(Nullable<Guid>))
                    {
                        Guid id;
                        if (Guid.TryParse(xValue, out id))
                            property.SetValue(obj, id);
                    }
                    else
                        throw new ApplicationException("Не могу преобразовать XElement, тип поля \"" + property.PropertyType.Name + "\"не определен!");
                }
                catch (Exception e)
                {
                    while (e.InnerException != null) e = e.InnerException;
                    throw new InvalidOperationException("Ошибка при преобразовании XElement в свойство сущности. Описание: " + e.Message);
                }
            }
            return obj;
        }

        public IEnumerable<T> ParseList<T>(IEnumerable<XElement> xList, bool fromAttribute = false)
        {
            return from xObj in xList
                   select ParseTo<T>(xObj, fromAttribute);
        }

        public XElement WrapFrom<T>(T obj)
        {
            var xObj = new XElement(typeof(T).Name);
            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(bool) && property.Name == "IsNew")
                {
                    xObj.SetAttributeValue("IsNew", property.GetValue(obj));
                }
                else
                {
                    var xProperty = new XElement(property.Name);
                    var val = property.GetValue(obj);
                    if (val != null)
                        xProperty.SetValue(val);
                    xObj.Add(xProperty);
                }
            }
            return xObj;
        }


        public T Get<T>(Guid Id)
        {
            var xObj = context.GetElements(typeof(T).Name + "s").FirstOrDefault(x => Guid.Parse(x.Element("Id").Value) == Id);
            if (xObj != null)
                return ParseTo<T>(xObj);
            return default(T);
        }

        public IEnumerable<T> GetAll<T>()
        {
            var xList = context.GetElements(typeof(T).Name + "s");
            if (xList != null && xList.Count() > 0)
                return ParseList<T>(xList);
            return null;
        }

        public void Save<T>(T obj, bool isUpdated = false)
        {
            if (!isUpdated)
                context.AddElement(WrapFrom(obj), typeof(T).Name + "s");
            else
                context.UpdateElement(WrapFrom(obj), typeof(T).Name + "s");
        }
    }
}
