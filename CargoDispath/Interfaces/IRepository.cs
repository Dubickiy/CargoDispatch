using System.Collections.Generic;

namespace CargoDispath.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetUserAll(string UserId);
        IEnumerable<T> GetAll();
        T Get(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int? id);
        IEnumerable<T> Find(T item);
    }
}
