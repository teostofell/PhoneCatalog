using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
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
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var roles = _rolesService.GetRoles();
                var rolesVm = _mapper.Map<List<RoleViewModel>>(roles);
                response = Request.CreateResponse(HttpStatusCode.OK, rolesVm);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // PUT: api/Roles/5
        public async Task<HttpResponseMessage> Put(string id, [FromUri] string userId)
        {
            HttpResponseMessage response;
            try
            {
                await _rolesService.ChangeRole(userId, id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }
    }
}