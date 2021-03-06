﻿using System;
using System.Diagnostics;
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
            var userVm = _mapper.Map<UserViewModel>(userDto);

            userVm.IsAdmin = await _userService.GetRole(userDto.Id) == Constants.PrivilegedRole;

            HttpResponseMessage response = null;

            if (userVm != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userVm);
            }

            return response;
        }

        // POST: api/Users
        public async Task<HttpResponseMessage> Post([FromBody]UserViewModel user)
        {
            var userDto = _mapper.Map<UserDto>(user);

            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            string thumbPath = ImagesProcessor.GetUserAvatar(user.Avatar, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            userDto.Avatar = thumbUrl;

            HttpResponseMessage response;
            try
            {
                await _userService.Register(userDto);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.OK, e.Message);
            }            

            return response;
        }
    }
}
