using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.DataTransferObjects
{
    public class UserDto
    {
        public string Email { get; set; }

        public UserDto(string email)
        {
            this.Email = email;
        }

        public UserDto(User user)
        {
            this.Email = user.Email;
        }
    }
}
