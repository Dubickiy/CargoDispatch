using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class LocateCarController : Controller
    {
        // GET: LocateCar
        [Authorize]
        public ActionResult LocateCar()
        {
            return View();
        }
    }
}