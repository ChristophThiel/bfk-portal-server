using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Persistence.Repositories;

namespace BfkPortal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        internal ApplicationDbContext Context;

        public IGenericRepository<Appointment> Appointments { get; }

        public IGenericRepository<Offer> Offers { get; }

        public IGenericRepository<Organisation> Organisations { get; }

        public IGenericRepository<Role> Roles { get; }

        public IGenericRepository<User> Users { get; }

        public UnitOfWork()
        {
            Context = new ApplicationDbContext();
            Appointments = new GenericRepository<Appointment>(Context);
            Offers = new GenericRepository<Offer>(Context);
            Organisations = new GenericRepository<Organisation>(Context);
            Roles = new GenericRepository<Role>(Context);
            Users = new GenericRepository<User>(Context);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch
            {
                Console.WriteLine("An error occured during the save operation!");
            }
        }

        public async Task DropDatabaseAsync() => await Context.Database.EnsureDeletedAsync();

        public async Task CreatDatabaseAsync() => await Context.Database.EnsureCreatedAsync();

        public IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.PropertyType == typeof(IGenericRepository<TEntity>))
                    return property.GetValue(this) as IGenericRepository<TEntity>;
            }

            return null;
        }

        public void Dispose() => Context.Dispose();
    }
}
