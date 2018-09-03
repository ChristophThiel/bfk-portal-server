namespace BfkPortal.Models
{
    public class AppointmentOrganisation
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; }
    }
}
