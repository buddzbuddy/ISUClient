using Domain.Models.Contingent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group Get(Guid Id);
        void Save(Group obj);
        void Delete(Group obj);
    }
}
