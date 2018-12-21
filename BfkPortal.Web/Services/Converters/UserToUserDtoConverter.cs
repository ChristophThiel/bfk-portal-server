using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class UserToUserDtoConverter : IConverter<User, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<Organisation, OrganisationDto> _organisationToOrganisationDtoConverter;

        public UserToUserDtoConverter(IUnitOfWork unitOfWork, IConverter<Organisation, OrganisationDto> organiaOrganisationToOrganisationDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _organisationToOrganisationDtoConverter = organiaOrganisationToOrganisationDtoConverter;
        }

        public async Task<UserDto> Convert(User source)
        {
            var destination = new UserDto
            {
                Id = source.Id,
                Firstname = source.Firstname,
                Lastname = source.Lastname,
                Telephone = source.Telephone,
                Email = source.Email,
                IsDeleted = source.IsDeleted
            };

            destination.Entitlements = source.Entitlements.Select(e => _unitOfWork.Roles.FindAsync(e.RoleId).Result.Name);
            destination.Memberships = source.Memberships
                .Select(m => _organisationToOrganisationDtoConverter
                    .Convert(_unitOfWork.Organisations.FindAsync(m.OrganisationId).Result).Result);

            return destination;
        }
    }
}
