using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CatalogApp.BLL.Services
{
    public class RolesService : BaseService, IRolesService
    {
        public RolesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) { }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var roles = unitOfWork.RoleManager.Roles.ToList();
            return mapper.Map<List<RoleDTO>>(roles);
        }


        public async Task<OperationDetails> ChangeRole(string userId, string roleId)
        {
            IList<string> roles;
           
            try
            {
                roles = await unitOfWork.UserManager.GetRolesAsync(userId);
            }
            catch (Exception e)
            {
                return new OperationDetails(false, $"Error on getting roles. {e.Message}");
            }

            await unitOfWork.UserManager.RemoveFromRolesAsync(userId, roles.ToArray());

            var role = await unitOfWork.RoleManager.FindByIdAsync(roleId);

            await unitOfWork.UserManager.AddToRoleAsync(userId, role.Name);

            await unitOfWork.SaveAsync();

            return new OperationDetails(true, "Role has been changed");
        }
    }
}
