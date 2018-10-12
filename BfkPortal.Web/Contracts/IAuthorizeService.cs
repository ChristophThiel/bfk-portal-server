using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Contracts
{
    public interface IAuthorizeService
    {
        IUnitOfWork UnitOfWork { get; }

        UserManager<User> UserManager { get; }

        RoleManager<Role> RoleManager { get; }

        Task<bool> IsOwner(int appointmentId, string email);

        Task<bool> IsAdminBfk(string email);

        Task<bool> IsAdminBwst(string email);
    }
}
