using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Services;
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
    public class PhotosController : ApiController
    {
        private IPhotoService db;
        private IMapper mapper;

        public PhotosController(IPhotoService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<PhotoDTO, PhotoVM>();
            }).CreateMapper();

        }

        // GET: api/Photos
        [HttpGet]
        public IEnumerable<PhotoVM> GetPhonePhotos(int phoneId)
        {
            var photos = db.GetPhonePhotos(phoneId);
            return mapper.Map<List<PhotoVM>>(photos);
        }

        // GET: api/Photos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Photos/?userId=*
        public async Task<HttpResponseMessage> SetUserAvatar(string userId, [FromBody]AvatarVM avatar)
        {
            string fileName = Path.GetRandomFileName() + ".png";
            string thumbPath = ImagesProcessor.GetUserAvatar(avatar.Photo, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            var result = await db.SetProfileAvatar(userId, thumbUrl);

            if (result.isSucceed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, thumbUrl);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        // POST: api/Photos/?phoneId=*
        public async Task<HttpResponseMessage> AddPhonePhoto(int phoneId, [FromBody]AvatarVM photo)
        {
            string fileName = Path.GetRandomFileName() + ".png";
            string thumbPath = ImagesProcessor.GetPhoneImage(photo.Photo, fileName, new Size(193, 410));
            string thumbUrl = Url.Content(thumbPath);

            var result = await db.AddPhonePhoto(phoneId, thumbUrl);

            if (result.isSucceed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, thumbUrl);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        // PUT: api/Photos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Photos/5
        public void Delete(int id)
        {
            db.DeletePhonePhoto(id);
        }
    }
}
