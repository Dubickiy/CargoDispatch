using CargoDispath.DAL.EF;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace CargoDispath.Controllers.ViewController
{
    public class LocateCargoController : Controller
    {
        private CargoContext db = new CargoContext("DBConnection");
        // GET: LocateCargo
        [Authorize]
        public ActionResult Locate()
        {
            return View();
        }
        [Authorize]
        public ActionResult GetCountries()
        {
            db._Countries.Load();
            var data = db._Countries.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult GetRegions(string id)
        {

            db._Regions.Load();
            var data = db._Regions.Where(a => a.Country.Name == id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult GetLoadingTypes()
        {
            db._LoadignTypes.Load();
            var data = db._LoadignTypes.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetCarTypes()
        {
            db._CarTypes.Load();
            var data = db._CarTypes.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}