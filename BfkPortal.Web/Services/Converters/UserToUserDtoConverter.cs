using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class UserToUserDtoConverter : IConverter<User, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConverter<Organisation, OrganisationDto> _organisationToOrganisationDtoConverter;

        public UserToUserDtoConverter(IUnitOfWork unitOfWork, UserManager<User> userManager,
            RoleManager<Role> roleManager, IConverter<Organisation, OrganisationDto> organiaOrganisationToOrganisationDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _organisationToOrganisationDtoConverter = organiaOrganisationToOrganisationDtoConverter;
        }

        public async Task<UserDto> Convert(User source)
        {
            var destination = new UserDto
            {
                Id = source.Id,
                Firstname = source.Firstname,
                Lastname = source.Lastname,
                Email = source.Email,
                IsDeleted = source.IsDeleted
            };

            destination.Entitlements = await _userManager.GetRolesAsync(source);

            var organisations = new List<OrganisationDto>();
            foreach (var membership in source.Memberships)
            {
                var organisation = await _unitOfWork.Organisations.FindAsync(membership.OrganisationId);
                organisations.Add(await _organisationToOrganisationDtoConverter.Convert(organisation));
            }
            destination.Memberships = organisations;

            return destination;
        }
    }
}
