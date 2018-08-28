using System;
using System.Threading.Tasks;

namespace BfkPortal.Database.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationRepository Authentications { get; }

        IUserRepository Users { get; }

        IAppointmentRepository Appointments { get; }

        IOrganisationRepository Organisations { get; }

        IUserAppointmentRepository UserAppointments { get; }

        Task<int> SaveChangesAsync();

        Task<bool> DeleteAsync();
    }
}
