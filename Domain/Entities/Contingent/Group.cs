using Domain.Filters;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Group : LocalEntity
    {
        [EnumMember("Language")]
        public Guid? Language { get; set; }
        [DocMember(typeof(Profession))]
        public Guid? Profession { get; set; }
        [EnumMember("StudyPeriod")]
        public Guid? StudyPeriod { get; set; }
        public string Name { get; set; }
    }
}
