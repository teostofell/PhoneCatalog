using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Register(UserDTO user);
        Task<UserDTO> FindUser(string userName, string password);
        Task<UserDTO> FindUser(string email);
        Task<string> GetRole(string id);
    }
}
