using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IAuthenticationService
    {
        object GenerateJsonWebToken(UserDto user);

        Task<UserDto> LogIn(CredentialsViewModel viewModel);

        Task Register(UserViewModel viewModel);
    }
}
