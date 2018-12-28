using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Persistence.Repositories;

namespace BfkPortal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IGenericRepository<Appointment> Appointments { get; }

        public IGenericRepository<Offer> Offers { get; }

        public IGenericRepository<Organisation> Organisations { get; }

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<Role> Roles { get; }

        public IGenericRepository<File> Files { get; }

        public IGenericRepository<Membership> Memberships { get; }

        public IGenericRepository<Participation> Participations { get; }

        public IGenericRepository<Entitlement> Entitlements { get; }

        public IGenericRepository<Possession> Possessions { get; }

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Appointments = new GenericRepository<Appointment>(_context);
            Offers = new GenericRepository<Offer>(_context);
            Organisations = new GenericRepository<Organisation>(_context);
            Users = new GenericRepository<User>(_context);
            Roles = new GenericRepository<Role>(_context);
            Files = new GenericRepository<File>(_context);
            Memberships = new GenericRepository<Membership>(_context);
            Participations = new GenericRepository<Participation>(_context);
            Entitlements = new GenericRepository<Entitlement>(_context);
            Possessions = new GenericRepository<Possession>(_context);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var next = e;
                while (next.InnerException != null)
                    next = next.InnerException;
                Console.WriteLine(next.Message);
            }
        }

        public async Task DeleteDatabaseAsync() => await _context.Database.EnsureDeletedAsync();

        public async Task CreateDatabaseAsync() => await _context.Database.EnsureCreatedAsync();

        public void Dispose() => _context.Dispose();
    }
}
