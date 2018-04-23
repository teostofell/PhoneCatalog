using CatalogApp.DAL.Entities;
using System;
using System.Linq;

namespace CatalogApp.DAL.Interfaces
{
    public interface IProfileManager : IDisposable
    {
        void Create(UserProfile item);
        IQueryable<UserProfile> GetAll();
        IQueryable<UserProfile> Get(string userId);
        void Update(UserProfile item);
    }
}
