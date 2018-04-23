using CatalogApp.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
