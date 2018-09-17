using System;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        internal DbContext Context;

        public IGenericRepository<Appointment> Appointments { get; }

        public IGenericRepository<Offer> Offers { get; }

        public IGenericRepository<Organisation> Organisations { get; }

        public IGenericRepository<Role> Roles { get; }

        public IGenericRepository<User> Users { get; }

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            this.Appointments = new GenericRepository<Appointment>(context);
            this.Offers = new GenericRepository<Offer>(context);
            this.Organisations = new GenericRepository<Organisation>(context);
            this.Roles = new GenericRepository<Role>(context);
            this.Users = new GenericRepository<User>(context);
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

        public void Dispose() => Context.Dispose();
    }
}
