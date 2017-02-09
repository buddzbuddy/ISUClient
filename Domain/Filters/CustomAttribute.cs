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
    public class BoundWithAttribute : Attribute
    {
        private string _propertyName { get; set; }
        public BoundWithAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }
        public string PropertyName { get { return _propertyName; } }
    }
    public class MemberAttribute : Attribute
    {
        private string _display { get; set; }
        private string _value { get; set; }
        public MemberAttribute(string display, string value = "Id")
        {
            _display = display;
            _value = value;
        }
        public string Display { get { return _display; } }
        public string Value { get { return _value; } }
    }
}
