using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class OrganisationToOrganisationDtoConverter : IConverter<Organisation, OrganisationDto>
    {
        public async Task<OrganisationDto> Convert(Organisation source)
        {
            return await Task.Factory.StartNew(() => new OrganisationDto
            {
                Id = source.Id,
                Name = source.Name,
                IsDeleted = source.IsDeleted
            });
        }
    }
}
