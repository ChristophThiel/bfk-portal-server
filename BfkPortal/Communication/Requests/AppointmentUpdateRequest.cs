using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.Requests
{
    public class AppointmentUpdateRequest : AppointmentBaseRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
