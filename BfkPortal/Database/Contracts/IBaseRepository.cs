using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Database.Contracts
{
    public interface IBaseRepository<T>
    {
        bool Add(T entity);

        Task<bool> Delete(int id);

        bool Update(T entity);

        Task<T> Find(int id);

        Task<List<T>> All();
    }
}
