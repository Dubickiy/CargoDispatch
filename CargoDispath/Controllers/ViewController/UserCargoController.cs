using CargoDispath.DAL.Repositories;
using System.Web.Mvc;
namespace CargoDispath.Controllers.ViewController
{
    public class UserCargoController : Controller
    {
        private EFUnitOfWork unitOfWork;
        public UserCargoController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
        // GET: AllCargos
        [Authorize]
        public ActionResult AllUserCargos()
        {
            return View();
        }
        [Authorize]
        public ActionResult AllUserCars()
        {
            return View();
        }
    }
}