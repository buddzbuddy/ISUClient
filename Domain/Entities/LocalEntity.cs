using Domain.Filters;
using System;

namespace Domain.Entities
{
    public abstract class LocalEntity
    {
        public Guid Id { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool IsDeleted { get; set; }
        private bool _IsModified = false;
        public bool IsModified { get { return _IsModified; } set { _IsModified = value; } }
    }
}
