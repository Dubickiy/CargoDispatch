using Microsoft.AspNet.Identity.EntityFramework;

namespace CargoDispath.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            
        }
        public int Year { get; set; }
       
    }
}