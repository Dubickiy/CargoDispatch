using CargoDispath.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class ProfileController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        string currentUser;
        // GET: Profile
        public ActionResult ProfilePage()
        {
            currentUser = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(currentUser);
            ViewBag.User = user;
            return View(user);
        }
    }
}