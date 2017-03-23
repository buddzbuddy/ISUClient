using Domain.Entities.Contingent;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class Education : LocalEntity
    {
        [BoundWith("EmployeeObj")]
        public Guid Employee { get; set; }
        [Skip]
        public Employee EmployeeObj { get; set; }
        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }

        [EnumMember("EducationDocumentType")]
        public Guid? EducationDocumentType { get; set; }

        public string EducationDocumentNo { get; set; }

        [EnumMember("EducationDocumentStatus")]
        public Guid? EducationDocumentStatus { get; set; }

        public DateTime? FinishDate { get; set; }

        public string Profession2 { get; set; }

        public string UniversityName { get; set; }
    }
}
