using Domain.Entities.Contingent;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class WorkPlace:LocalEntity
    {
        [BoundWith("EmployeeObj")]
        public Guid Employee { get; set; }
        [Skip]
        public Employee EmployeeObj { get; set; }
        public string Name { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }
        public string Profession2 { get; set; }

        #region Должность

        public bool? Government { get; set; }
        public bool? Leadership { get; set; }
        public bool? Pedagogical { get; set; }
        public bool? Vocational { get; set; }

        #endregion
    }
}
