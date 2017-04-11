using CargoDispath.DAL.EF;
using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoDispath.DAL.Repositories
{
    internal class CarRepository:IRepository<Car>
    {
        private CargoContext db;
        public CarRepository(CargoContext context)
        {
            this.db = context; 
        }

        public void Create(Car item)
        {
            db._Cars.Add(item);
            //throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            Car car = db._Cars.Find(id);
            if (car != null)
            {
                db._Cars.Remove(car);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Car> Find(Car item)
        {
            throw new NotImplementedException();
        }

        public Car Get(int? id)
        {
            return db._Cars.Find(id);
           // throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll(string UserId)
        {
            return db._Cars;
            //throw new NotImplementedException();
        }

        public IEnumerable<Car> GetUserAll(string UserId)
        {
            return db._Cars.Where(a => a.UserId == UserId);
            //throw new NotImplementedException();
        }

        public void Update(Car item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
           // throw new NotImplementedException();
        }
    }
}
