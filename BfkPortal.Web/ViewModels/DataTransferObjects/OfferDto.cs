using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class OfferDto
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public UserDto Sender { get; set; }

        public AppointmentDto SenderAppointment { get; set; }

        public UserDto Receiver { get; set; }

        public AppointmentDto ReceiverAppointment { get; set; }
    }
}
