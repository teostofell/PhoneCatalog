using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class RolesService : BaseService, IRolesService
    {
        public RolesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) { }

        public IEnumerable<RoleDto> GetRoles()
        {
            var roles = UnitOfWork.RoleManager.Roles.ToList();
            return Mapper.Map<List<RoleDto>>(roles);
        }


        public async Task<OperationDetails> ChangeRole(string userId, string roleId)
        {
            IList<string> roles;
           
            try
            {
                roles = await UnitOfWork.UserManager.GetRolesAsync(userId);
            }
            catch (Exception e)
            {
                return new OperationDetails(false, $"Error on getting roles. {e.Message}");
            }

            await UnitOfWork.UserManager.RemoveFromRolesAsync(userId, roles.ToArray());

            var role = await UnitOfWork.RoleManager.FindByIdAsync(roleId);

            await UnitOfWork.UserManager.AddToRoleAsync(userId, role.Name);

            await UnitOfWork.SaveAsync();

            return new OperationDetails(true, "Role has been changed");
        }
    }
}
