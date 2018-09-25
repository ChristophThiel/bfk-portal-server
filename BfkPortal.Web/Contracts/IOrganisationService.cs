using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IOrganisationService : IGenericService<Organisation, OrganisationViewModel, OrganisationDto>
    {
        
    }
}
