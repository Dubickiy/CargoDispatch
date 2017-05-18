using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CargoDispath.Models
{
    public class ConfirmInfoModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}