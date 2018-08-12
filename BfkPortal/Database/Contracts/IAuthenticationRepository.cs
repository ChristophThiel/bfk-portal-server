using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<User> Verify(string email, string password);
    }
}
