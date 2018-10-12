using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IUserService : IGenericService<User, UserViewModel, UserDto>
    {

    }
}
