using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserRepository
    {
        Task Add(string email, string password);

        Task<User> GetById(int id);
    }
}
