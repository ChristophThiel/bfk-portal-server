namespace BfkPortal.DataTransferObjects
{
    public class AuthenticationDto
    {
        public string Token { get; set; }

        public UserDto User { get; set; }
    }
}
