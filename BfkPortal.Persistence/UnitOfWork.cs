﻿using System;
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

        public UnitOfWork()
        {
            this.Context = new ApplicationDbContext();
            this.Appointments = new GenericRepository<Appointment>(Context);
            this.Offers = new GenericRepository<Offer>(Context);
            this.Organisations = new GenericRepository<Organisation>(Context);
            this.Roles = new GenericRepository<Role>(Context);
            this.Users = new GenericRepository<User>(Context);
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

        public void Dispose() => Context.Dispose();
    }
}
