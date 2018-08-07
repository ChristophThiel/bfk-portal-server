using System.ComponentModel.DataAnnotations;

namespace BfkPortal.DataTransferObjects
{
    public class EmailDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
