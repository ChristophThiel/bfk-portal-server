using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class OfferDto
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public OfferDto(Offer o)
        {
            Id = o.Id;
            Status = o.Status.ToString();
        }
    }
}
