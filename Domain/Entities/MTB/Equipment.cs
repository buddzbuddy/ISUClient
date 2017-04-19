using Domain.Entities.Contingent;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.MTB
{
    public class Equipment : LocalEntity
    {
        [EnumMember("EquipmentCategory")]
        public Guid? EquipmentCategory { get; set; }

        public string Model { get; set; }

        public int? Amount { get; set; }

        public int? ReleseYear { get; set; }

        public string SupplierSource { get; set; }

        public decimal? Price { get; set; }

        public decimal? Wear { get; set; }

        [EnumMember("State")]
        public Guid? State { get; set; }

        [DocMember(typeof(Sector))]
        public Guid? Sector { get; set; }

        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }
    }
}
