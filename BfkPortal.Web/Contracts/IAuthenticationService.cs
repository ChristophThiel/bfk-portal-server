using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IAuthenticationService
    {
        Task Register(UserViewModel viewModel);

        Task<UserDto> LogIn(CredentialsViewModel viewModel);

        object GenerateJsonWebToken(UserDto user);
    }
}
