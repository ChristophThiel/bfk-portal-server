using System.Collections.Generic;

namespace BfkPortal.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
