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
        public Guid? LanguageId { get; set; }
        public Guid? ProfessionId { get; set; }
        public Guid? StudyPeriodId { get; set; }
    }
}
