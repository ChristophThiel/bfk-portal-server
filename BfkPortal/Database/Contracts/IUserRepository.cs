using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<bool> Delete(int id);

        Task<bool> Update(UserUpdateRequest update);

        Task<User> Find(int id);

        Task<IEnumerable<UserDto>> All();

        
    }
}
