using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class RolesController : ApiController
    {
        private readonly IRolesService _rolesService;
        private readonly IMapper _mapper;

        public RolesController(IRolesService context, IMapper mapper)
        {
            _rolesService = context;
            _mapper = mapper; 
        }

        // GET: api/Roles
        public IEnumerable<RoleVm> Get()
        {
            var roles = _rolesService.GetRoles();
            return _mapper.Map<List<RoleVm>>(roles);
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
            var result = await _rolesService.ChangeRole(userId, id);

            if(result.IsSucceed)
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
