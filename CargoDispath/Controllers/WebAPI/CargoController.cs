using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Repositories;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;

namespace CargoDispath.Controllers.WebAPI
{
    public class CargoController : ApiController
    {
        private EFUnitOfWork unitOfWork;
        string currentUserId;
        public CargoController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
        [Route("api/cargo/AddCargo")]
        [HttpPost]
        public void AddCargo([FromBody] Cargo cargo)
        {
            currentUserId = User.Identity.GetUserId();
            cargo.UserId = currentUserId;
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

        [HttpDelete]
        public void Delete(int? id)
        {
            unitOfWork.Cargos.Delete(id);
            unitOfWork.Save();
        }
    }
}
