using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Repositories;
using CargoDispath.Entities;
using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class SearchController : Controller
    {
        EFUnitOfWork unitOfWork;
        public SearchController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
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


        [HttpGet]
        public ActionResult SearchCargoInfo(int? id)
        {
            Cargo cargo = unitOfWork.Cargos.Get(id);
            ViewBag.From = cargo;
            return View(cargo);
            //return View("~/Views/Search/SearchCargoInfo.cshtml");
            ///////////////////
        }
        [HttpGet]
        public ActionResult SearchCarInfo(int? id)
        {
            UserCars car = unitOfWork.UserCars.Get(id);
            ViewBag.From = car;
            return View(car);
            //return View("~/Views/Search/SearchCargoInfo.cshtml");
            ///////////////////
        }

    }
}