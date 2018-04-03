using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(int id);
        IQueryable<T> Find(Func<T, bool> predicate);
        T Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
