using System;
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
        private readonly DbContext _context;

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

        public async Task<T> FindAsync(int id, params string[] includes)
        {
            var query = All(includes).AsQueryable();
            var entity = await query.SingleOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public IEnumerable<T> All(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query;
        }
    }
}
