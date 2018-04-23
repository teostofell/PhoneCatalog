using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Interfaces;
using System;
using System.Linq;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private readonly CatalogContext _db;

        public Repository(CatalogContext context)
        {
            _db = context;
        }

        public T Create(T item)
        {
            var a = _db.Set<T>().Add(item);

            return a;
        }

        public void Delete(int id)
        {
            T toDelete = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(toDelete);
        }

        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            return _db.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> Get(int id)
        {
            return _db.Set<T>().Where(t => t.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
