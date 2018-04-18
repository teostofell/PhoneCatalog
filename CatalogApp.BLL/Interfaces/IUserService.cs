using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    // TODO: I implemented IDisposeable here cuz I need to use it in using()-blocks (see Provider class in API layer)
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Register(UserDTO user);
        Task<UserDTO> FindUser(string userName, string password);
        Task<UserDTO> FindUser(string email);
        Task<string> GetRole(string id);
        List<UserDTO> GetUsers();
    }
}
