using Domain.Filters;
using System;

namespace Domain.Entities
{
    public abstract class LocalEntity
    {
        public Guid Id { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
