namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class OfferDto : EntityDto
    {
        public string Status { get; set; }

        public UserDto Sender { get; set; }

        public AppointmentDto SenderAppointment { get; set; }

        public UserDto Receiver { get; set; }

        public AppointmentDto ReceiverAppointment { get; set; }
    }
}
