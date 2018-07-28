using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfkPortal.Database.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);

        T Find(int id);

        T Find(T entity);

        void Remove(T entity);

        IEnumerable<T> All();
    }
}
