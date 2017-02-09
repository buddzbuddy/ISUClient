using Domain.Filters;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : LocalEntity
    {
        public string PIN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        [EnumMember("Gender", "FullName")]
        public Guid? Gender { get; set; }
        [EnumMember("Nationality", "FullName")]
        public Guid? Nationality { get; set; }
    }
}
