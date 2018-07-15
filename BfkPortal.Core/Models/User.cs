using System.Collections.Generic;

namespace BfkPortal.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public List<Role> Roles { get; set; }

        public User()
        {
            this.Id = 0;
            this.Email = "";
            this.Password = "";
            this.Salt = "";
            this.Roles = new List<Role>();
        }

        public User(string email, string password, string salt)
        {
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
            this.Roles = new List<Role>();
        }

        public override string ToString() => Email;
    }
}
