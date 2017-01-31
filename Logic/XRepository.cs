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
        public T ParseTo<T>(XElement xObj)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));
            foreach (var property in obj.GetType().GetProperties())
            {
                try
                {
                    var xValue = xObj.Element(property.Name).Value;
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
                        property.SetValue(obj, Boolean.Parse(xValue));
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

        public IEnumerable<T> ParseList<T>(IEnumerable<XElement> xList)
        {
            return from xObj in xList
                   select ParseTo<T>(xObj);
        }

        public XElement WrapFrom<T>(T obj)
        {
            var xObj = new XElement(typeof(T).Name);
            foreach (var property in obj.GetType().GetProperties())
            {
                var xProperty = new XElement(property.Name);
                xProperty.SetValue(property.GetValue(obj));
                xObj.Add(xProperty);
            }
            return xObj;
        }
    }
}
