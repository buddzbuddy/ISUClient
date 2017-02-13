using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class District : LocalEntity
    {
        public string Name { get; set; }
        public Guid Area { get; set; }
    }
}
