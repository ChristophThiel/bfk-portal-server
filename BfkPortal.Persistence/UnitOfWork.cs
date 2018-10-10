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

        public IGenericRepository<Membership> Memberships { get; }

        public IGenericRepository<Participation> Participations { get; }

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Appointments = new GenericRepository<Appointment>(_context);
            Offers = new GenericRepository<Offer>(_context);
            Organisations = new GenericRepository<Organisation>(_context);
            Users = new GenericRepository<User>(_context);
            Memberships = new GenericRepository<Membership>(_context);
            Participations = new GenericRepository<Participation>(_context);
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

        public async Task CreatDatabaseAsync() => await _context.Database.EnsureCreatedAsync();

        public void Dispose() => _context.Dispose();
    }
}
