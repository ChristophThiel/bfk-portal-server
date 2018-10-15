namespace BfkPortal.Core.Models
{
    public class Possession : EntityObject
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int FileId { get; set; }

        public File File { get; set; }
    }
}
