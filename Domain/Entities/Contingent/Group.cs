using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Group : LocalEntity
    {
        [Member("FullName")]
        public Guid? Language { get; set; }
        [Member("Name")]
        public Guid? Profession { get; set; }
        [Member("FullName")]
        public Guid? StudyPeriod { get; set; }
        public string Name { get; set; }
    }
}
