namespace BfkPortal.Core.Models
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

        public User(int id, string email, string password, string salt)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
        }

        public override string ToString() => Email;
    }
}
