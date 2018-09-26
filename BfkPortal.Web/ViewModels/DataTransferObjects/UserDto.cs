using System.Collections.Generic;
using System.Linq;
using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<OrganisationDto> Organisations { get; set; }

        public UserDto(User u)
        {
            Id = u.Id;
            Firstname = u.Firstname;
            Lastname = u.Lastname;
            Email = u.Email;
            IsDeleted = u.IsDeleted;
            Roles = u.Entitlements?.Select(e => e.Role.Name);
            Organisations = u.Memberships?.Select(m => new OrganisationDto(m.Organisation));
        }
    }
}
