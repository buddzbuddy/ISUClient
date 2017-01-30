using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(object parentId);
        T GetByKey(object keyValue);

        void Insert(T entity, bool autoPersist = true);
        void Update(T entity, bool autoPersist = true);
        void Delete(T entity, bool autoPersist = true);

        void Save();
    }
}
