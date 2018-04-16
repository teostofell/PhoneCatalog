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
    public class RolesService : IRolesService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public RolesService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationRole, RoleDTO>();
            }).CreateMapper();
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var roles = Db.RoleManager.Roles.ToList();
            return mapper.Map<List<RoleDTO>>(roles);
        }


        public async Task<OperationDetails> ChangeRole(string userId, string roleId)
        {
            var roles = await Db.UserManager.GetRolesAsync(userId);
            await Db.UserManager.RemoveFromRolesAsync(userId, roles.ToArray());


            await Db.UserManager.AddToRoleAsync(userId, roleId);

            await Db.SaveAsync();

            return new OperationDetails(true, "Role has been changed");
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
