using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CargoDispath.Models
{
    public class EditProfile
    {

        public string Name { get; set; }

        public String Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

    }
}