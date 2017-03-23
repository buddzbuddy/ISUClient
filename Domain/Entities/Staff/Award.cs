using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class Award:LocalEntity
    {
        [BoundWith("EmployeeObj")]
        public Guid Employee { get; set; }
        [Skip]
        public Employee EmployeeObj { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string IssuedBy { get; set; }
    }
}
