using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Repositories;
using CargoDispath.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace CargoDispath.Controllers.WebAPI
{
    public class CargoController : ApiController
    {
        private EFUnitOfWork unitOfWork;
        string currentUserId;
        bool isAuthorize;
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
        public CargoController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
        
        [Route("api/cargo/AddCargo")]
       [Authorize]
        public   void AddCargo([FromBody] Cargo cargo)
        {
            currentUserId = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(currentUserId);
            var number =  UserManager.GetPhoneNumber(currentUserId);
            cargo.UserId = currentUserId;
            cargo.PhoneNumber = number;
            cargo.UserName = user.Name + " " + user.Surname;
            cargo.UserAdress = user.Adress;
            unitOfWork.Cargos.Create(cargo);
            unitOfWork.Save();
           
            
        }
        [Route("api/cargo/GetUserAll")]
        [HttpGet]
        public IEnumerable<Cargo> GetUserAll()
        {
            
            currentUserId = User.Identity.GetUserId();
            return unitOfWork.Cargos.GetUserAll(currentUserId);
        }
        [Route("api/cargo/Find")]
        [HttpGet]
        public IEnumerable<Cargo> Find([FromUri]Cargo cargo)
        {
            currentUserId = User.Identity.GetUserId();
            return unitOfWork.Cargos.Find(cargo);
        }
        [Route("api/cargo/GetAll")]
        [HttpGet]
        public IEnumerable<Cargo> GetAll()
        {
            
            return unitOfWork.Cargos.GetAll();
        }
        //[Route("api/cargo/Delete")]
        [HttpDelete]
        public void Delete(int? id)
        {
            unitOfWork.Cargos.Delete(id);
            unitOfWork.Save();
        }
    }
}
