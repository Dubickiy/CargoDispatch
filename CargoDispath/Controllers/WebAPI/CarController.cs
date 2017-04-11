using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CargoDispath.Controllers.WebAPI
{
    public class CarController : ApiController
    {
        private EFUnitOfWork unitOfWork;
        string currentUserId;
        public CarController()
        {
            unitOfWork = new EFUnitOfWork("DBConnection");
        }
        [Route("api/car/AddCar")]
        [HttpPost]
        public void AddCar([FromBody] Car car)
        {
            currentUserId = User.Identity.GetUserId();
            car.UserId = currentUserId;
            unitOfWork.Cars.Create(car);
            unitOfWork.Save();
        }
        [Route("api/car/GetAll")]
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            currentUserId = User.Identity.GetUserId();
            return unitOfWork.Cars.GetUserAll(currentUserId);
        }
        [HttpDelete]
        public void Delete(int? id)
        {
            unitOfWork.Cars.Delete(id);
        }
        
    }
}
