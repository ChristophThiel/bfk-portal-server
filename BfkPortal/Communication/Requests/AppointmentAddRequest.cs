using System.ComponentModel.DataAnnotations;
using BfkPortal.Models.Enums;

namespace BfkPortal.Communication.Requests
{
    public class AppointmentAddRequest : AppointmentBaseRequest
    {
        [Required, EnumDataType(typeof(AppointmentTypes), ErrorMessage = "Value is not a valid type for an appointment")]
        public string Type { get; set; }
    }
}
