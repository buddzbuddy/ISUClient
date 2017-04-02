using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MTB
{
    public class Building:LocalEntity
    {
        [EnumMember("BuildingPurpose")]
        public Guid? BuildingPurpose { get; set; }
        [EnumMember("BuildingType")]
        public Guid? BuildingType { get; set; }

        public int? BuildYear { get; set; }
        public int? ExploitationYear { get; set; }
        public int? FloorAmount { get; set; }
        [EnumMember("YesNo")]
        public Guid? Electrosupply { get; set; }
        #region Площадь здания

        public double? BuildingArea { get; set; }
        public double? UnusefulArea { get; set; }
        public double? UsefulArea { get; set; }
        public double? RentedArea { get; set; }
        public decimal? RentPrice { get; set; }
        public double? HiredArea { get; set; }
        public decimal? HirePrice { get; set; }

        #endregion
        [EnumMember("RoofType")]
        public Guid? RoofType { get; set; }
        [EnumMember("State")]
        public Guid? RoofState { get; set; }
        [EnumMember("YesNo")]
        public Guid? WaterSupply { get; set; }
        [EnumMember("State")]
        public Guid? WaterSupplyState { get; set; }
        [EnumMember("YesNo")]
        public Guid? Sewerage { get; set; }
        [EnumMember("State")]
        public Guid? SewerageState { get; set; }
        [EnumMember("HeatingSystem")]
        public Guid? HeatingSystem { get; set; }
        [EnumMember("State")]
        public Guid? HeatingSystemState { get; set; }

    }
}
