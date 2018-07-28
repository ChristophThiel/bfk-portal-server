using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Interfaces
{
    public interface IUserRepository
    {
        void Add(string email, string password);
    }
}
