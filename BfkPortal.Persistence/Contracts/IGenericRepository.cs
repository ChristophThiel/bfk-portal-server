using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Persistence.Contracts
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        Task<T> FindAsync(int id);

        /* Task LoadCollectionAsync(T entity, string propertyName);

        Task LoadReferenceAsync(T entity, string propertyName); */

        IEnumerable<T> All();
    }
}
