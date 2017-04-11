using Microsoft.AspNet.Identity.EntityFramework;
namespace CargoDispath.Models
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole()
        {

        }
        public string Description { get; set; }
    }
}