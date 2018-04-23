using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService context, IMapper mapper)
        {
            _userService = context;
            _mapper = mapper;
        }

        // GET: api/Users
        public async Task<HttpResponseMessage> Get()
        {
            var users = _userService.GetUsers();

            var response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
        }

        // GET: api/Users?email=*
        public async Task<HttpResponseMessage> Get(string email)
        {
            var userDto = await _userService.FindUser(email);
            var userVm = _mapper.Map<UserVm>(userDto);

            userVm.IsAdmin = await _userService.GetRole(userDto.Id) == "admin";

            HttpResponseMessage response = null;

            if (userVm != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userVm);
            }

            return response;
        }

        // POST: api/Users
        public async Task<HttpResponseMessage> Post([FromBody]UserVm user)
        {
            var userDto = _mapper.Map<UserDto>(user);

            string fileName = Path.GetRandomFileName() + ".png";
            string thumbPath = ImagesProcessor.GetUserAvatar(user.Avatar, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            userDto.Avatar = thumbUrl;
            var result = await _userService.Register(userDto);

            HttpResponseMessage response;

            if(!result.IsSucceed)
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
        public void Put(int id, [FromBody]UserDto user)
        {

        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
