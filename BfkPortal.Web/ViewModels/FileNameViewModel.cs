using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class FileNameViewModel
    {
        [Required]
        public string FileName { get; set; }
    }
}
