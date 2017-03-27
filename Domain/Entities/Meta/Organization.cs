using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Meta
{
    public class Organization
    {
        public Guid OrgUnitId { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string FullName { get; set; }
        public Guid ParentId { get; set; }
        public string Description { get; set; }
        public int OrderIndex { get; set; }
    }

    public class Worker
    {
        public Guid PositionId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Guid ParentId { get; set; }
        public string Description { get; set; }
        public int OrderIndex { get; set; }
    }
}
