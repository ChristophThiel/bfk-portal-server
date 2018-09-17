using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Core.Contracts
{
    public interface IGenericRepository<T> where T : IEntityObject
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        Task<T> FindAsync(int id);

        IEnumerable<T> All();
    }
}
