using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Group : LocalEntity
    {
        public Guid? Language { get; set; }
        public Guid? Profession { get; set; }
        public Guid? StudyPeriod { get; set; }
        public string Name { get; set; }
    }
}
