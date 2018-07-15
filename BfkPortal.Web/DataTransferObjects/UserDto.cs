using BfkPortal.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BfkPortal.Web.DataTransferObjects
{
    public class UserDto
    {
        public string Email { get; set; }

        public List<Role> Roles { get; set; }

        public UserDto()
        {
            this.Email = "";
            this.Roles = new List<Role>();
        }

        public UserDto(User user)
        {
            this.Email = user.Email;
            this.Roles = user.Roles;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
