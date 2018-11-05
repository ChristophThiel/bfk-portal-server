using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> All();

        IEnumerable<UserDto> AllUsersOfSameRoleGroup(params string[] roles);

        Task Remove(int id);

        IEnumerable<string> Roles();

        IEnumerable<string> RolesOfRoleGroup(params string[] roles);

        Task Update(UserViewModel viewModel);
    }
}
