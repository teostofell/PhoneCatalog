﻿using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public async Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response;

            var users = db.GetUsers();

            response = Request.CreateResponse(HttpStatusCode.OK, users);

            return response;
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
        public async Task<HttpResponseMessage> Post([FromBody]UserVM user)
        {
            var userDTO = mapper.Map<UserDTO>(user);

            string fileName = Path.GetRandomFileName() + ".png";
            string thumbPath = ImagesProcessor.GetUserAvatar(user.Avatar, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            userDTO.Avatar = thumbUrl;
            var result = await db.Register(userDTO);

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
