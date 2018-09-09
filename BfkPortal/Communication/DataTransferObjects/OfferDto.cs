using BfkPortal.Models;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class OfferDto
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public AppointmentDto SenderAppointment { get; set; }

        public AppointmentDto ReceiverAppointment { get; set; }

        public UserDto Sender { get; set; }

        public UserDto Receiver { get; set; }

        public OfferDto(Offer o)
        {
            this.Id = o.Id;
            this.Status = o.Status.ToString();
            this.SenderAppointment = new AppointmentDto(o.SenderAppointment);
            this.ReceiverAppointment = new AppointmentDto(o.ReceiverAppointment);
            this.Sender = new UserDto(o.Sender);
            this.Receiver = new UserDto(o.Receiver);
        }
    }
}
