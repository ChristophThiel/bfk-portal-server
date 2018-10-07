﻿using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class LogInViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
