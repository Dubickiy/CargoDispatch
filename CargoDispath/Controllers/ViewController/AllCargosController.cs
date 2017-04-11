using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class AllCargosController : Controller
    {
        // GET: AllCargos
        [Authorize]
        public ActionResult AllCargos()
        {
            return View();
        }
        [Authorize]
        public ActionResult AllCars()
        {
            return View();
        }
    }
}