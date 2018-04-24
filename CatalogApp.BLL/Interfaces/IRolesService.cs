using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IRolesService
    {
        IEnumerable<RoleDto> GetRoles();
        Task ChangeRole(string userId, string roleId);
    }
}
