using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfkPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public User()
        {
            this.Id = 0;
            this.Email = "";
            this.Password = "";
            this.Salt = "";
        }

        public User(string email, string password, string salt)
        {
            this.Id = 0;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
        }
    }
}
