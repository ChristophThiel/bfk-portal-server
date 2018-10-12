using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityObject
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
            var includes = typeof(T).GetProperties()
                .Where(p => p.GetType() == typeof(EntityObject))
                .Select(p => p.Name);
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in properties)
                query.Include(include)
            //var entity = await _context.FindAsync<T>(id);
            var entity = query.Fi
            await query.SingleOrDefaultAsync();
            return entity;
        }

        /* public async Task LoadCollectionAsync(T entity, string propertyName) => 
            await Context.Entry(entity).Collection(propertyName).LoadAsync();

        public async Task LoadReferenceAsync(T entity, string propertyName) =>
            await Context.Entry(entity).Reference(propertyName).LoadAsync(); */

        public IEnumerable<T> All() => _context.Set<T>().ToList();
    }
}
