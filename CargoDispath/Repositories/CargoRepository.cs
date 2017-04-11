using CargoDispath.DAL.EF;
using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CargoDispath.DAL.Repositories
{
    internal class CargoRepository:IRepository<Cargo>
    {
        private CargoContext db;
        public CargoRepository(CargoContext context)
        {
            this.db = context;
        }

        public void Create(Cargo item)
        {
            db._Cargos.Add(item);
            //throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            Cargo cargo = db._Cargos.Find(id);
            if(cargo!= null)
            {
                db._Cargos.Remove(cargo);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Cargo> Find(Cargo item)
        {
            IEnumerable<Cargo> data = new List<Cargo>();
           
            if (item.IsElectronic)
            {
                if (item.FromCountry != "" & item.FromRegion != "" & item.FromCity != "" & item.ToCounry != "" & item.ToRegion != "" & item.ToCity != ""
                    & item.LoadingType != "" & item.CarType != "")
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.FromCountry == item.FromCountry
                    && a.FromRegion == item.FromRegion
                    && a.FromCity == item.FromCity
                    && a.ToCounry == item.ToCounry
                    && a.ToRegion == item.ToRegion
                    && a.ToCity == item.ToCity
                    && a.LoadingType == item.LoadingType
                    && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.FromCountry))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.FromCountry == item.FromCountry);

                }
                if (!string.IsNullOrEmpty(item.FromRegion))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.FromRegion == item.FromRegion);
                }
                if (!string.IsNullOrEmpty(item.FromCity))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.FromCity == item.FromCity);
                }
                if (!string.IsNullOrEmpty(item.ToCounry))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.ToCounry == item.ToCounry);
                }
                if (!string.IsNullOrEmpty(item.ToRegion))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.ToRegion == item.ToRegion);
                }
                if (!string.IsNullOrEmpty(item.ToCity))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.ToCity == item.ToCity);
                }
                if (!string.IsNullOrEmpty(item.CarType))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.LoadingType))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.LoadingType == item.LoadingType);
                }
                if (!string.IsNullOrEmpty(item.TimeOfNeccessaryLoading))
                {
                    data = db._Cargos.Where(a => a.IsElectronic == item.IsElectronic && a.TimeOfNeccessaryLoading == item.TimeOfNeccessaryLoading);

                }

            }
            else
            {
                if (item.FromCountry != "" & item.FromRegion != "" & item.FromCity != "" & item.ToCounry != "" & item.ToRegion != "" & item.ToCity != ""
                   & item.LoadingType != "" & item.CarType != "")
                {
                    data = db._Cargos.Where(a =>a.FromCountry == item.FromCountry
                    && a.FromRegion == item.FromRegion
                    && a.FromCity == item.FromCity
                    && a.ToCounry == item.ToCounry
                    && a.ToRegion == item.ToRegion
                    && a.ToCity == item.ToCity
                    && a.LoadingType == item.LoadingType
                    && a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.FromCountry))
                {
                    data = db._Cargos.Where(a =>  a.FromCountry == item.FromCountry);

                }
                if (!string.IsNullOrEmpty(item.FromRegion))
                {
                    data = db._Cargos.Where(a =>  a.FromRegion == item.FromRegion);
                }
                if (!string.IsNullOrEmpty(item.FromCity))
                {
                    data = db._Cargos.Where(a => a.FromCity == item.FromCity);
                }
                if (!string.IsNullOrEmpty(item.ToCounry))
                {
                    data = db._Cargos.Where(a =>  a.ToCounry == item.ToCounry);
                }
                if (!string.IsNullOrEmpty(item.ToRegion))
                {
                    data = db._Cargos.Where(a => a.ToRegion == item.ToRegion);
                }
                if (!string.IsNullOrEmpty(item.ToCity))
                {
                    data = db._Cargos.Where(a =>  a.ToCity == item.ToCity);
                }
                if (!string.IsNullOrEmpty(item.CarType))
                {
                    data = db._Cargos.Where(a =>  a.CarType == item.CarType);
                }
                if (!string.IsNullOrEmpty(item.LoadingType))
                {
                    data = db._Cargos.Where(a => a.LoadingType == item.LoadingType);
                }
                if (!string.IsNullOrEmpty(item.TimeOfNeccessaryLoading))
                {
                    data = db._Cargos.Where(a => a.TimeOfNeccessaryLoading == item.TimeOfNeccessaryLoading);

                }
            }
            return data;
            //throw new NotImplementedException();
        }

        public Cargo Get(int? id)
        {
            return db._Cargos.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Cargo> GetAll()
        {
            return db._Cargos;
            //throw new NotImplementedException();
        }

        public IEnumerable<Cargo> GetUserAll(string UserId)
        {
            
            return db._Cargos.Where(a=>a.UserId == UserId);
            //throw new NotImplementedException();
        }

        public void Update(Cargo item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //throw new NotImplementedException();
        }
    }
}
