using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IRolesService : IDisposable
    {
        IEnumerable<RoleDTO> GetRoles();
        Task<OperationDetails> ChangeRole(string userId, string roleId);
    }
}
