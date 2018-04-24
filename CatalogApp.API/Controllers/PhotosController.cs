using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class PhotosController : ApiController
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public PhotosController(IPhotoService context, IMapper mapper)
        {
            _photoService = context;
            _mapper = mapper;
        }

        // GET: api/Photos
        [HttpGet]
        public IEnumerable<PhotoViewModel> GetPhonePhotos(int phoneId)
        {
            var photos = _photoService.GetPhonePhotos(phoneId);
            return _mapper.Map<List<PhotoViewModel>>(photos);
        }

        // POST: api/Photos/?userId=*
        public async Task<HttpResponseMessage> SetUserAvatar(string userId, [FromBody] AvatarViewModel avatar)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            string thumbPath = ImagesProcessor.GetUserAvatar(avatar.Photo, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            HttpResponseMessage response;
            try
            {
                await _photoService.SetProfileAvatar(userId, thumbUrl);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // POST: api/Photos/?phoneId=*
        public async Task<HttpResponseMessage> AddPhonePhoto(int phoneId, [FromBody] AvatarViewModel photo)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            string thumbPath = ImagesProcessor.GetPhoneImage(photo.Photo, fileName, new Size(193, 410));
            string thumbUrl = Url.Content(thumbPath);

            HttpResponseMessage response;
            try
            {
                await _photoService.AddPhonePhoto(phoneId, thumbUrl);
                response = Request.CreateResponse(HttpStatusCode.OK, thumbUrl);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // DELETE: api/Photos/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response;
            try
            {
                await _photoService.DeletePhonePhoto(id);
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