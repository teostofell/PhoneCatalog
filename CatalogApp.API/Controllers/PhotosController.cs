using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.Services;
using System.Collections.Generic;
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
        public async Task<HttpResponseMessage> SetUserAvatar(string userId, [FromBody]AvatarViewModel avatar)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            string thumbPath = ImagesProcessor.GetUserAvatar(avatar.Photo, fileName, new Size(200, 200));
            string thumbUrl = Url.Content(thumbPath);

            var result = await _photoService.SetProfileAvatar(userId, thumbUrl);

            if (result.IsSucceed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, thumbUrl);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        // POST: api/Photos/?phoneId=*
        public async Task<HttpResponseMessage> AddPhonePhoto(int phoneId, [FromBody]AvatarViewModel photo)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            string thumbPath = ImagesProcessor.GetPhoneImage(photo.Photo, fileName, new Size(193, 410));
            string thumbUrl = Url.Content(thumbPath);

            var result = await _photoService.AddPhonePhoto(phoneId, thumbUrl);

            if (result.IsSucceed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, thumbUrl);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }
    }
}
