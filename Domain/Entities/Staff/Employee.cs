using Domain.Entities.Contingent;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class Employee : LocalEntity
    {
        [BoundWith("PersonObj")]
        public Guid Person { get; set; }

        [Skip]
        public Person PersonObj { get; set; }

        #region Passport details

        public string PassportSeries { get; set; }

        public string PassportNo { get; set; }

        public DateTime? PassportDate { get; set; }

        public string PassportOrg { get; set; }
        #endregion

        [EnumMember("MaritalStatus")]
        public Guid? MaritalStatus { get; set; }

        [EnumMember("StaffType")]
        public Guid? StaffType { get; set; }

        [EnumMember("Teacher")]
        public Guid? Teacher { get; set; }

        [DocMember(typeof(Position))]
        public Guid? Position { get; set; }

        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }

        #region Address details

        [DocMember(typeof(Area))]
        public Guid? Area { get; set; }

        [DocMember(typeof(District))]
        public Guid? District { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Apartment { get; set; }

        #endregion

        #region Contacts

        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        #endregion

        #region Сведения о воинском учете

        [EnumMember("YesNo")]
        public Guid? EnabledToMilitary { get; set; }

        public string MilitaryPosition { get; set; }

        public string MilitaryDistrictOfficeName { get; set; }

        #endregion

        #region Стаж

        #region По основной профессии
        [Skip]
        public int GenExperienceYears { get; set; }
        [Skip]
        public int GenExperienceMonths { get; set; }
        [Skip]
        public int GenExperienceDays { get; set; }
        #endregion

        #region Общий
        [Skip]
        public int ExperienceYears { get; set; }
        [Skip]
        public int ExperienceMonths { get; set; }
        [Skip]
        public int ExperienceDays { get; set; }

        #endregion

        #region Руководящий
        [Skip]
        public int LeadershipExperienceYears { get; set; }
        [Skip]
        public int LeadershipExperienceMonths { get; set; }
        [Skip]
        public int LeadershipExperienceDays { get; set; }

        #endregion

        #region Педагогический
        [Skip]
        public int PedagogicalExperienceYears { get; set; }
        [Skip]
        public int PedagogicalExperienceMonths { get; set; }
        [Skip]
        public int PedagogicalExperienceDays { get; set; }

        #endregion

        #region в ПТО
        [Skip]
        public int VocationalExperienceYears { get; set; }
        [Skip]
        public int VocationalExperienceMonths { get; set; }
        [Skip]
        public int VocationalExperienceDays { get; set; }

        #endregion

        #region Госсужба
        [Skip]
        public int GovernmentExperienceYears { get; set; }
        [Skip]
        public int GovernmentExperienceMonths { get; set; }
        [Skip]
        public int GovernmentExperienceDays { get; set; }
        #endregion

        #endregion
    }
}
