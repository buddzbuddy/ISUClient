using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Sector : LocalEntity
    {
        public string Name { get; set; }
        [Skip]
        public List<Profession> Professions { get; set; }
    }
}
