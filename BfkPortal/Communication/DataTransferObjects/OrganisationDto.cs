using BfkPortal.Models;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class OrganisationDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool IsDeleted { get; set; }

        public OrganisationDto() { }

        public OrganisationDto(Organisation o)
        {
            this.Id = o.Id;
            this.Name = o.Name;
            this.IsDeleted = o.IsDeleted;
        }
    }
}
