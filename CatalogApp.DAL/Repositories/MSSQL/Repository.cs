using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private CatalogContext db;

        public Repository(CatalogContext context)
        {
            db = context;
        }

        public T Create(T item)
        {
            var a = db.Set<T>().Add(item);

            return a;
        }

        public void Delete(int id)
        {
            T toDelete = db.Set<T>().Find(id);
            db.Set<T>().Remove(toDelete);
        }

        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> Get(int id)
        {
            return db.Set<T>().Where(t => t.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public void Update(T item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
