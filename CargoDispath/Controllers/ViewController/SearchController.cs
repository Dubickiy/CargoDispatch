using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Repositories;
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
        }

    }
}