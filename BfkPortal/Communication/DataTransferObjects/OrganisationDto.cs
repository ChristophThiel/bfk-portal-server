using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class OrganisationDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
