using Domain.Filters;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Student:LocalEntity
    {
        #region About Student
        [BoundWith("PersonObj")]
        public Guid Person { get; set; }
        [Skip]
        public Person PersonObj { get; set; }

        #region PassportDetails
        [EnumMember("PersonalDocumentType", "FullName")]
        public Guid? PersonalDocumentType { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNo { get; set; }
        public Guid? Citizenship { get; set; }


        #endregion

        #region RegAddress

        public Guid? Area { get; set; }
        public Guid? District { get; set; }
        public string  Address { get; set; }

        #endregion

        public bool IsNeedHostel { get; set; }

        #region Contacts

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        #endregion

        public bool HasCriminalRecord { get; set; }

        public Guid? SocialStatus { get; set; }
        public bool IsDisability { get; set; }
        public Guid? MilitaryStatus { get; set; }

        #endregion

        #region Current education details

        public Guid? EducationType { get; set; }
        public Guid? EducationDocumentType { get; set; }
        public string EducationDocumentNo { get; set; }
        public Guid? EducationDocumentStatus { get; set; }
        public int? SecondaryEducationYear { get; set; }
        public Guid? SchoolType { get; set; }
        public string SchoolName { get; set; }

        #endregion

        #region Enrollment details

        public Guid? ReceiptType { get; set; }
        public Guid? StudyPeriod { get; set; }
        public int? Year { get; set; }
        public Guid? Sector { get; set; }
        public Guid? Profession { get; set; }
        public Guid? StudyMode { get; set; }
        public Guid? EducationDirection { get; set; }
        public Guid? PayType { get; set; }
        public Guid? EducationEndType { get; set; }


        #endregion

        #region Learning details

        public Guid? AdmittedToQualifExam { get; set; }
        public Guid? AdmittedToResultExam { get; set; }
        public Guid? PassedQualifExam { get; set; }
        public Guid? PassedResultExam { get; set; }
        [DocMember("Name", typeof(Group))]
        public Guid? Group { get; set; }

        #endregion

        #region Graduate info

        public Guid? JobOrganization { get; set; }
        public Guid? JobDirection { get; set; }

        #endregion
    }
}
