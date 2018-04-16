using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class RolesController : ApiController
    {
        private IRolesService db;
        private IMapper mapper;

        public RolesController(IRolesService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, RoleVM>();
            }).CreateMapper();

        }

        // GET: api/Roles
        public IEnumerable<RoleVM> Get()
        {
            var roles = db.GetRoles();
            return mapper.Map<List<RoleVM>>(roles);
        }

        // GET: api/Roles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Roles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Roles/5
        public void Put(string id, [FromUri]string userId)
        {
            db.ChangeRole(userId, id);
        }

        // DELETE: api/Roles/5
        public void Delete(int id)
        {
        }
    }
}
