using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Profession { get; set; }
        public string StudyPeriod { get; set; }
    }
}
