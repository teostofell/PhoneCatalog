using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System.Linq;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class ProfileManager : IProfileManager
    {
        private readonly CatalogContext _db;

        public ProfileManager(CatalogContext context)
        {
            _db = context;
        }

        public void Create(UserProfile item)
        {
            _db.UserProfiles.Add(item);

        }

        public IQueryable<UserProfile> Get(string userId)
        {
            return _db.UserProfiles.Where(p => p.Id == userId);
        }

        public void Update(UserProfile item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<UserProfile> GetAll()
        {
            return _db.UserProfiles;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
