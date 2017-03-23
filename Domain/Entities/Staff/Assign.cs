using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class Assign:LocalEntity
    {
        [BoundWith("EmployeeObj")]
        public Guid Employee { get; set; }
        [Skip]
        public Employee EmployeeObj { get; set; }

        public DateTime RegDate { get; set; }

        [DocMember(typeof(Position))]
        public Guid? Position { get; set; }

        [EnumMember("WorkingConditions")]
        public Guid? WorkingConditions { get; set; }

        #region Основание

        public string OnBasedName { get; set; }
        public string OnBasedNo { get; set; }
        public DateTime? OnBasedDate { get; set; }

        #endregion

        public double HoursPerMonth { get; set; }
    }
}
