using CargoDispath.DAL.Repositories;
using CargoDispath.Entities;
using CargoDispath.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace CargoDispath.Controllers.WebAPI
{
    public class UserCarController : ApiController
    {
        private EFUnitOfWork unitOfWork;
        string currentUserId;
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        public UserCarController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
        [Route("api/usercar/AddCar")]
        [HttpPost]
        public void AddUserCar([FromBody] UserCars car)
        {
            currentUserId = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(currentUserId);
            var number = UserManager.GetPhoneNumber(currentUserId);
            car.UserAdress = user.Adress;
            car.UserName = user.Name + " " + user.Surname;
            car.PhoneNumber = number;
            car.UserId = currentUserId;
            unitOfWork.UserCars.Create(car);
            unitOfWork.Save();
        }
        [Route("api/usercar/Find")]
        [HttpGet]
        public IEnumerable<UserCars> Find([FromUri] UserCars car)
        {
            return unitOfWork.UserCars.Find(car);
        }
        [Route("api/usercars/GetAll")]
        [HttpGet]
        public IEnumerable<UserCars> GetAll()
        {
            return unitOfWork.UserCars.GetAll();
        }
        [Route("api/usercars/GetUserAll")]
        [HttpGet]
        public IEnumerable<UserCars> GetUserAll()
        {
            currentUserId = User.Identity.GetUserId();
            return unitOfWork.UserCars.GetUserAll(currentUserId);
        }
        [HttpDelete]
        public void Delete(int? id)
        {
            unitOfWork.UserCars.Delete(id);
            unitOfWork.Save();
        }
    }
}
