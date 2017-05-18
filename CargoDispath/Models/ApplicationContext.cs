using Microsoft.AspNet.Identity.EntityFramework;

namespace CargoDispath.Models
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
            :base("UserConnection")
        {

        }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}