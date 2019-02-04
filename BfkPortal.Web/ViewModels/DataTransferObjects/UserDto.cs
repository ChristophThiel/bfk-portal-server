using System.Collections.Generic;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class UserDto : EntityDto
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<string> Entitlements { get; set; }

        public IEnumerable<OrganisationDto> Memberships { get; set; }
        
        public IEnumerable<PreferenceDto> Preferences { get; set; }
    }
}
