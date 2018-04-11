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
    public class UsersController : ApiController
    {
        private IUserService db;
        private IMapper mapper;

        public UsersController(IUserService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            }).CreateMapper();

        }

        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users?email=*
        public async Task<HttpResponseMessage> Get(string email)
        {
            var userDto = await db.FindUser(email);
            var userVm = mapper.Map<UserVM>(userDto);

            userVm.IsAdmin = await db.GetRole(userDto.Id) == "admin";

            HttpResponseMessage response = null;

            if (userVm != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userVm);
            }

            return response;
        }

        // POST: api/Users
        public async Task<HttpResponseMessage> Post([FromBody]UserDTO user)
        {
            var result = await db.Register(user);
            HttpResponseMessage response;

            if(!result.isSucceed)
            {
                HttpError err = new HttpError(result.Message);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }

            return response;
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]UserDTO user)
        {

        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
