using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoDispath.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        //[Display(Name = "Почта")]
        public string Email { get; set; }
    }
}