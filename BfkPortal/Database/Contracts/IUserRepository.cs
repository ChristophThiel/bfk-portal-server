using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserRepository
    {
        Task Add(string email, string password);

        Task<User> Find(int id);

        Task<IEnumerable<UserDto>> All();
    }
}
