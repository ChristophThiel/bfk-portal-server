using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserRepository
    {
        Task Add(string email, string password);

        Task<User> Find(int id);

        Task<IEnumerable<UserDto>> All();

        Task Remove(int userId);

        Task Update(UserDto body);
    }
}
