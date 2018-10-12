using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class OrganisationToOrganisationDtoConverter : IConverter<Organisation, OrganisationDto>
    {
        public Task<OrganisationDto> Convert(Organisation source)
        {
            var destination = new OrganisationDto
            {
                Id = source.Id,
                Name = source.Name,
                IsDeleted = source.IsDeleted
            };

            return destination;
        }
    }
}
