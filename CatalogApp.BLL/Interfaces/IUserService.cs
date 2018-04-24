using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    // TODO: I implemented IDisposeable here cuz I need to use it in using()-blocks (see Provider class in API layer)
    public interface IUserService : IDisposable
    {
        Task Register(UserDto user);
        Task<UserDto> FindUser(string userName, string password);
        Task<UserDto> FindUser(string email);
        Task<string> GetRole(string id);
        List<UserDto> GetUsers();
    }
}
