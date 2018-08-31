using BfkPortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        public bool IsDeleted { get; set; }

        public ICollection<RoleDto> Roles { get; set; }

        public ICollection<OrganisationDto> Organisations { get; set; }

        public UserDto() { }

        public UserDto(User u)
        {
            this.Id = u.Id;
            this.Firstname = u.Firstname;
            this.Lastname = u.Lastname;
            this.Email = u.Email;
            this.IsDeleted = u.IsDeleted;
            this.Roles = u.Roles.Select(r => new RoleDto(r.Role)).ToList();
            this.Organisations = u.Organisations.Select(o => new OrganisationDto(o.Organisation)).ToList();
        }
    }
}
