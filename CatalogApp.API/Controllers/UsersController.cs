using AutoMapper;
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
            var user = await db.FindUser(email);
            HttpResponseMessage response = null;

            if (user != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, user);
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
