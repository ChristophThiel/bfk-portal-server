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

        public OfferDto(Offer o)
        {
            /* Id = o.Id;
            Status = o.Status.ToString();
            Sender = new UserDto(o.Sender);
            SenderAppointment = new AppointmentDto(o.SenderAppointment);
            Receiver = new UserDto(o.Receiver);
            ReceiverAppointment = new AppointmentDto(o.ReceiverAppointment); */
        }
    }
}
