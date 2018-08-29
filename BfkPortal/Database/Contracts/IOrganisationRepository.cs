using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IOrganisationRepository
    {
        Task<Organisation> Find(int id);

        Task<IEnumerable<OrganisationDto>> All();
    }
}
