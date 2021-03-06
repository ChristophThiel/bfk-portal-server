﻿using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Web.ViewModels
{
    public class OfferViewModel : EntityViewModel
    {
        [Required]
        [EnumDataType(typeof(OfferStatus), ErrorMessage = "This is not a valid type!")]
        public OfferStatus? Status { get; set; } 

        [Required]
        public int? SenderAppointmentId { get; set; }

        [Required]
        public int? ReceiverAppointmentId { get; set; }

        [Required]
        public int? SenderId { get; set; }

        [Required]
        public int? ReceiverId { get; set; }
    }
}
