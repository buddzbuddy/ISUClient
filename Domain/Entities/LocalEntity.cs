using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class LocalEntity
    {
        public Guid Id { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
    }
}
