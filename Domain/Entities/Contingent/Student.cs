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
        [EnumMember("PersonalDocumentType")]
        public Guid? PersonalDocumentType { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNo { get; set; }
        [EnumMember("Citizenship")]
        public Guid? Citizenship { get; set; }


        #endregion

        #region RegAddress
        [DocMember(typeof(Area))]
        public Guid? Area { get; set; }
        [DocMember(typeof(District))]
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
        [EnumMember("SocialStatus")]
        public Guid? SocialStatus { get; set; }
        public bool IsDisability { get; set; }
        [EnumMember("MilitaryStatus")]
        public Guid? MilitaryStatus { get; set; }

        #endregion

        #region Current education details
        [EnumMember("EducationType")]
        public Guid? EducationType { get; set; }
        [EnumMember("EducationDocumentType")]
        public Guid? EducationDocumentType { get; set; }
        public string EducationDocumentNo { get; set; }
        [EnumMember("EducationDocumentStatus")]
        public Guid? EducationDocumentStatus { get; set; }
        public int? SecondaryEducationYear { get; set; }
        [EnumMember("SchoolType")]
        public Guid? SchoolType { get; set; }
        public string SchoolName { get; set; }

        #endregion

        #region Enrollment details
        [EnumMember("ReceiptType")]
        public Guid? ReceiptType { get; set; }
        public int? Year { get; set; }
        [EnumMember("StudyPeriod")]
        public Guid? StudyPeriod { get; set; }
        [DocMember(typeof(Sector))]
        public Guid? Sector { get; set; }
        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }
        [EnumMember("StudyMode")]
        public Guid? StudyMode { get; set; }
        [EnumMember("EducationDirection")]
        public Guid? EducationDirection { get; set; }
        [EnumMember("PayType")]
        public Guid? PayType { get; set; }
        [EnumMember("EducationEndType")]
        public Guid? EducationEndType { get; set; }


        #endregion

        #region Learning details

        [DocMember(typeof(Group))]
        public Guid? Group { get; set; }
        [EnumMember("YesNo")]
        public Guid? AdmittedToQualifExam { get; set; }
        [EnumMember("YesNo")]
        public Guid? AdmittedToResultExam { get; set; }
        [EnumMember("YesNo")]
        public Guid? PassedQualifExam { get; set; }
        [EnumMember("YesNo")]
        public Guid? PassedResultExam { get; set; }

        #endregion

        #region Graduate info

        public Guid? JobOrganization { get; set; }
        public Guid? JobDirection { get; set; }

        #endregion
    }
}
