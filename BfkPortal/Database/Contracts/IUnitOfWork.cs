using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfkPortal.Database.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationRepository Authentications { get; }

        IUserRepository Users { get; }

        IAppointmentRepository Appointments { get; }

        Task<int> SaveChangesAsync();

        Task<bool> DeleteAsync();
    }
}
