using System.Collections.Generic;

namespace BfkPortal.DataTransferObjects
{
    public class UserDto
    {
        public string Email { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
