using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IRoleRepository
    {
        Task<Role> Find(int id);

        Task<IEnumerable<Role>> All();
    }
}
