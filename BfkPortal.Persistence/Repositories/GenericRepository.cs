using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Add(entity);

        public void AddRange(IEnumerable<T> entities) => _context.AddRange(entities);

        public void Remove(T entity) => _context.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _context.RemoveRange(entities);

        public void Update(T entity) => _context.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => _context.UpdateRange(entities);

        public async Task<T> FindAsync(int id)
        {
            await _context.Set<T>().LoadAsync();
            var entity = await _context.FindAsync<T>(id);
            return entity;
        }

        /* public async Task LoadCollectionAsync(T entity, string propertyName) => 
            await Context.Entry(entity).Collection(propertyName).LoadAsync();

        public async Task LoadReferenceAsync(T entity, string propertyName) =>
            await Context.Entry(entity).Reference(propertyName).LoadAsync(); */

        public IEnumerable<T> All() => _context.Set<T>().ToList();
    }
}
