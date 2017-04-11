using CargoDispath.DAL.EF;
using CargoDispath.DAL.Entities;
using CargoDispath.DAL.Interfaces;
using System;

namespace CargoDispath.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private CargoContext db;
        private CargoRepository cargoRepository;
        private CarRepository carRepository;

        public IRepository<Cargo> Cargos
        {
            get
            {
                if(cargoRepository == null)
                {
                    cargoRepository = new CargoRepository(db);
                }
                return cargoRepository;
                //throw new NotImplementedException();

            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if(carRepository == null)
                {
                    carRepository = new CarRepository(db);
                }
                return carRepository;
                //throw new NotImplementedException();
            }
        }
       
        public EFUnitOfWork(string connectionString)
        {
            db = new CargoContext(connectionString);
        }

        public void Save()
        {
            db.SaveChanges();
           // throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
