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


    }
}
