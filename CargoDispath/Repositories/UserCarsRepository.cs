using CargoDispath.DAL.EF;
using CargoDispath.DAL.Interfaces;
using CargoDispath.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoDispath.Repositories
{
    internal class UserCarsRepository : IRepository<UserCars>
    {
        private CargoContext db;
        public UserCarsRepository(CargoContext context)
        {
            this.db = context;
        }
        public void Create(UserCars item)
        {
            db._UserCars.Add(item);
            //throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            var car = db._UserCars.Find(id);
            if (car != null)
            {
                db._UserCars.Remove(car);
               
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<UserCars> Find(UserCars item)
        {
            throw new NotImplementedException();
        }

        public UserCars Get(int? id)
        {
            return db._UserCars.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<UserCars> GetAll()
        {
            return db._UserCars.ToList();
           // throw new NotImplementedException();
        }

        public IEnumerable<UserCars> GetUserAll(string UserId)
        {
            return db._UserCars.Where(a => a.UserId == UserId);
            //throw new NotImplementedException();
        }

        public void Update(UserCars item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //throw new NotImplementedException();
        }
    }
}