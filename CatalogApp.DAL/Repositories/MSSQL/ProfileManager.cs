using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class ProfileManager : IProfileManager
    {
        private CatalogContext db;

        public ProfileManager(CatalogContext context)
        {
            db = context;
        }

        public void Create(UserProfile item)
        {
            db.UserProfiles.Add(item);

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
