using BfkPortal.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class UserViewModel : EntityViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public bool? IsActivated { get; set; }

        public bool? IsDeleted { get; set; }

        public int? ShiftCount { get; set; }

        public bool? AvoidHolidays { get; set; }

        public KeyValuePair<int, DayOfWeek>? FixShift { get; set; }

        public ICollection<KeyValuePair<int, DayOfWeek>> AvoidFirstDays { get; set; }

        public ICollection<ShiftTypes> AvoidShiftTypes { get; set; }

        public ICollection<DayOfWeek> AvoidDays { get; set; }

        public ICollection<int> AvoidMonths { get; set; }

        public IEnumerable<string> Entitlements { get; set; }
        
        public IEnumerable<int> Memberships { get; set; }
    }
}
