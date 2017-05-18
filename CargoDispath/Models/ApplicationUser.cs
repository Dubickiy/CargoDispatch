using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CargoDispath.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            
        }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Adress { get; set; }

    }
}