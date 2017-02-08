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
    public class BindWithPropertyAttribute : Attribute
    {
        public virtual string PropertyName { get; set; }
    }
}
