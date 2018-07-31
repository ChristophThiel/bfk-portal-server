using System.Collections.Generic;
using BfkPortal.Models;

namespace BfkPortal.Database.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool Verify(string email, string password);

        // TODO Remove
        void Reset();
    }
}
