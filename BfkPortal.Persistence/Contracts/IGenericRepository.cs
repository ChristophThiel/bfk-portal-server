using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Persistence.Contracts
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        IEnumerable<T> All(params string[] includes);

        Task<T> FindAsync(int id, params string[] includes);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

    }
}
