using CargoDispath.DAL.EF;
using CargoDispath.DAL.Interfaces;
using CargoDispath.Entities;
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
            IEnumerable<UserCars> data = new List<UserCars>();

            if (item.IsElectronic)
            {
                if (item.FromCountry != "" & item.FromRegion != "" & item.FromCity != "" & item.ToCountry != "" & item.ToRegion != "" & item.ToCity != ""
                    & item.LoadingType != "" & item.CarType != "")
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.FromCountry == item.FromCountry
                    && a.FromRegion == item.FromRegion
                    && a.FromCity == item.FromCity
                    && a.ToCountry == item.ToCountry
                    && a.ToRegion == item.ToRegion
                    && a.ToCity == item.ToCity
                    && a.LoadingType == item.LoadingType
                    && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.FromCountry))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.FromCountry == item.FromCountry);

                }
                if (!string.IsNullOrEmpty(item.FromRegion))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.FromRegion == item.FromRegion);
                }
                if (!string.IsNullOrEmpty(item.FromCity))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.FromCity == item.FromCity);
                }
                if (!string.IsNullOrEmpty(item.ToCountry))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.ToCountry == item.ToCountry);
                }
                if (!string.IsNullOrEmpty(item.ToRegion))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.ToRegion == item.ToRegion);
                }
                if (!string.IsNullOrEmpty(item.ToCity))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.ToCity == item.ToCity);
                }
                if (!string.IsNullOrEmpty(item.CarType))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.LoadingType))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.LoadingType == item.LoadingType);
                }
                if (!string.IsNullOrEmpty(item.DateOfSending))
                {
                    data = db._UserCars.Where(a => a.IsElectronic == item.IsElectronic && a.DateOfSending == item.DateOfSending);

                }

            }
            else
            {
                if (item.FromCountry != "" & item.FromRegion != "" & item.FromCity != "" & item.ToCountry != "" & item.ToRegion != "" & item.ToCity != ""
                   & item.LoadingType != "" & item.CarType != "")
                {
                    data = db._UserCars.Where(a => a.FromCountry == item.FromCountry
                    && a.FromRegion == item.FromRegion
                    && a.FromCity == item.FromCity
                    && a.ToCountry == item.ToCountry
                    && a.ToRegion == item.ToRegion
                    && a.ToCity == item.ToCity
                    && a.LoadingType == item.LoadingType
                    && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.FromCountry))
                {
                    data = db._UserCars.Where(a => a.FromCountry == item.FromCountry);

                }
                if (!string.IsNullOrEmpty(item.FromRegion))
                {
                    data = db._UserCars.Where(a => a.FromRegion == item.FromRegion);
                }
                if (!string.IsNullOrEmpty(item.FromCity))
                {
                    data = db._UserCars.Where(a => a.FromCity == item.FromCity);
                }
                if (!string.IsNullOrEmpty(item.ToCountry))
                {
                    data = db._UserCars.Where(a => a.ToCountry == item.ToCountry);
                }
                if (!string.IsNullOrEmpty(item.ToRegion))
                {
                    data = db._UserCars.Where(a => a.ToRegion == item.ToRegion);
                }
                if (!string.IsNullOrEmpty(item.ToCity))
                {
                    data = db._UserCars.Where(a => a.ToCity == item.ToCity);
                }
                if (!string.IsNullOrEmpty(item.CarType))
                {
                    data = db._UserCars.Where(a => a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.LoadingType))
                {
                    data = db._UserCars.Where(a => a.LoadingType == item.LoadingType);
                }
                if (!string.IsNullOrEmpty(item.DateOfSending))
                {
                    data = db._UserCars.Where(a => a.DateOfSending == item.DateOfSending);

                }
            }
            return data;
            //throw new NotImplementedException();
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