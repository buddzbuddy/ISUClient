using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class EnumDef
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public List<EnumItem> Items { get; set; }
    }
    public class EnumItem
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
