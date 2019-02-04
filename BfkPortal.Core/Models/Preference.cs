using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Core.Models
{
    public class Preference : EntityObject
    {
        public bool Avoid  { get; set; }

        public PreferenceType Type { get; set; }

        public User User { get; set; }
    }
}
