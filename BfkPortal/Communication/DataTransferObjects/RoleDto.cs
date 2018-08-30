using BfkPortal.Models;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleDto() { }

        public RoleDto(Role r)
        {
            this.Id = r.Id;
            this.Name = r.Name;
        }
    }
}