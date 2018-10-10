using System.Threading.Tasks;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> CreateJsonWebTokenAsync(int id);

        bool VerifyPassword(string email, string password);

        Task<UserDto> FindByCredentialsAsync(string email, string password);
    }
}
