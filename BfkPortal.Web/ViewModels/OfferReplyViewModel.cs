using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Web.ViewModels
{
    public class OfferReplyViewModel
    {
        [Required]
        public int? OfferId { get; set; }

        [Required]
        [EnumDataType(typeof(OfferStatus), ErrorMessage = "This is not a valid type!")]
        public OfferStatus? Status { get; set; }
    }
}
