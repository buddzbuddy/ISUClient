using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class SkipAttribute : Attribute
    {

    }
    public class MarkAttribute : Attribute
    {

    }
    public class BoundWithAttribute : Attribute
    {
        private string _propertyName { get; set; }
        public BoundWithAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }
        public string PropertyName { get { return _propertyName; } }
    }
    public class DocMemberAttribute : Attribute
    {
        private string _display { get; set; }
        private string _value { get; set; }
        private Type _objType { get; set; }
        public DocMemberAttribute(string display, Type objType, string value = "Id")
        {
            _display = display;
            _value = value;
            _objType = objType;
        }

        public DocMemberAttribute(Type objType)
        {
            _display = "Name";
            _value = "Id";
            _objType = objType;
        }
        public string Display { get { return _display; } }
        public string Value { get { return _value; } }
        public Type ObjType { get { return _objType; } }
    }
    public class EnumMemberAttribute : Attribute
    {
        private string _display { get; set; }
        private string _value { get; set; }
        private string _enumDefName { get; set; }
        public EnumMemberAttribute(string enumDefName, string display = "FullName", string value = "Id")
        {
            _enumDefName = enumDefName;
            _display = display;
            _value = value;
        }
        public string Display { get { return _display; } }
        public string Value { get { return _value; } }
        public string EnumDefName { get { return _enumDefName; } }
    }
}
