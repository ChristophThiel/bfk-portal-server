using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BfkPortal.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext Context;
        internal DbSet<T> Set;

        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public void Add(T entity) => Set.Add(entity);

        public void AddRange(IEnumerable<T> entities) => Set.AddRange(entities);

        public void Remove(T entity) => Set.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => Set.RemoveRange(entities);

        public void Update(T entity) => Set.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => Set.UpdateRange(entities);

        public async Task<T> FindAsync(int id) => await Set.FindAsync(id);

        public async Task LoadCollectionAsync(T entity, string propertyName) => 
            await Context.Entry(entity).Collection(propertyName).LoadAsync();

        public async Task LoadReferenceAsync(T entity, string propertyName) =>
            await Context.Entry(entity).Reference(propertyName).LoadAsync();

        public IEnumerable<T> All() => Set;
    }
}
