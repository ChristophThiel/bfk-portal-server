namespace BfkPortal.DataTransferObjects
{
    public class AuthenticationDto
    {
        public string Token { get; set; }

        public UserDto User { get; set; }

        public AuthenticationDto(string token, UserDto user)
        {
            this.Token = token;
            this.User = user;
        }
    }
}
