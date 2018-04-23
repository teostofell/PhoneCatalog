using CatalogApp.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }
    }
}
