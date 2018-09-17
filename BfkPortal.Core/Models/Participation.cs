namespace BfkPortal.Core.Models
{
    public class Participation : EntityObject
    {
        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }

        public EntityObject EntityObject { get; set; }

        public int EntityObjectId { get; set; }
    }
}
