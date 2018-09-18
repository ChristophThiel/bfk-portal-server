using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;

namespace BfkPortal.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Appointment> Appointments { get; }

        IGenericRepository<Offer> Offers { get; }

        IGenericRepository<Organisation> Organisations { get; }

        IGenericRepository<Role> Roles { get; }

        IGenericRepository<User> Users { get; }

        Task SaveChangesAsync();

        Task DropDatabaseAsync();

        Task CreatDatabaseAsync();
    }
}
