using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class RolesController : ApiController
    {
        private IRolesService db;
        private IMapper mapper;

        public RolesController(IRolesService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper; 
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
        public async Task<HttpResponseMessage> Put(string id, [FromUri]string userId)
        {
            var result = await db.ChangeRole(userId, id);

            if(result.isSucceed)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        // DELETE: api/Roles/5
        public void Delete(int id)
        {
        }
    }
}
