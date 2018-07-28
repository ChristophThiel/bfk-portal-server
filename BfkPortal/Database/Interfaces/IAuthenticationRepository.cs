using System.Collections.Generic;
using BfkPortal.Models;

namespace BfkPortal.Database.Interfaces
{
    public interface IAuthenticationRepository : IBaseRepository<User>
    {
        bool Verify(string email, string password);

        void Reset();
    }
}
