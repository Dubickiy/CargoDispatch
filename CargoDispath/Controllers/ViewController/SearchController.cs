using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class SearchController : Controller
    {
        // GET: Search
        [Authorize]
        public ActionResult Search()
        {
            return View();
        }
        [Authorize]
        public ActionResult SearchCar()
        {
            return View();
        }
    }
}