using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> All();

        Task Remove(int id);

        IEnumerable<string> Roles();

        Task Update(UserViewModel viewModel);
    }
}
