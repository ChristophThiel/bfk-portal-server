using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;

namespace BfkPortal.Persistence.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Appointment> Appointments { get; }

        IGenericRepository<Offer> Offers { get; }

        IGenericRepository<Organisation> Organisations { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<Role> Roles { get; }

        IGenericRepository<Membership> Memberships { get; }

        IGenericRepository<Participation> Participations { get; }

        IGenericRepository<Entitlement> Entitlements { get; }

        Task SaveChangesAsync();

        Task DeleteDatabaseAsync();

        Task CreatDatabaseAsync();
    }
}
