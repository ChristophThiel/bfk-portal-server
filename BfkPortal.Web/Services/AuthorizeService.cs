using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        public IUnitOfWork UnitOfWork { get; }

        public UserManager<User> UserManager { get; }

        public RoleManager<Role> RoleManager { get; }

        public AuthorizeService(IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public async Task<bool> IsAdminBfk(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            return await UserManager.IsInRoleAsync(user, Constants.AdminBfk);
        }

        public async Task<bool> IsAdminBwst(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            return await UserManager.IsInRoleAsync(user, Constants.AdminBwst); ;
        }

        public async Task<bool> IsOwner(int appointmentId, string email)
        {
            var appointment = await UnitOfWork.Appointments.FindAsync(appointmentId);
            var user = UserManager.FindByEmailAsync(email);

            return appointment.OwnerId == user.Id;
        }
    }
}
