using CargoDispath.DAL.Entities;
using CargoDispath.Entities;
using System;

namespace CargoDispath.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Cargo> Cargos { get; }
        IRepository<Car> Cars { get; }


        void Save();
    }
}
