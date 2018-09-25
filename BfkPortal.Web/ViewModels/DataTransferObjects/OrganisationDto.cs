using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class OrganisationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public OrganisationDto(Organisation o)
        {
            Id = o.Id;
            Name = o.Name;
            IsDeleted = o.IsDeleted;
        }
    }
}
