using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
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
    public class PhonesController : ApiController
    {
        private readonly IPhonesService _phonesService;
        private readonly IMapper _mapper;

        public PhonesController(IPhonesService context, IMapper mapper)
        {
            _phonesService = context;
            _mapper = mapper;
        }

        public async Task<HttpResponseMessage> Get([FromUri] FilterViewModel filter)
        {
            PageViewModel result = new PageViewModel();

            var filterModel = _mapper.Map<FilterModel>(filter);

            result.Items =
                _mapper.Map<List<PhoneSummaryViewModel>>(_phonesService.GetPhones(filterModel, filter.ItemsOnPage,
                    filter.Page));

            result.TotalItems = _phonesService.TotalItems;
            result.TotalPages = _phonesService.TotalPages;

            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }

        // GET: api/Phones/id
        public async Task<HttpResponseMessage> Get(int id)
        {
            HttpResponseMessage response = null;

            PhoneDto phone = _phonesService.GetPhone(id);

            response = Request.CreateResponse(HttpStatusCode.OK, phone);

            return response;
        }

        // GET: api/Phones/?search=*
        [HttpGet]
        public HttpResponseMessage Search(string search)
        {
            IEnumerable<PhoneDto> phones = _phonesService.SearchPhones(search);

            var response = Request.CreateResponse(HttpStatusCode.OK, phones);

            return response;
        }

        // GET: api/Phones/?slug=*
        [HttpGet]
        public async Task<HttpResponseMessage> GetBySlug(string slug)
        {
            HttpResponseMessage response = null;

            PhoneDto phone = _phonesService.GetPhone(slug);

            response = Request.CreateResponse(HttpStatusCode.OK, phone);

            return response;
        }

        // POST: api/Phones
        [Authorize(Roles = Constants.PrivilegedRole)]
        public async Task<HttpResponseMessage> Post([FromBody] PhoneDto phone)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            var thumbPath = ImagesProcessor.GetPhoneThumbnail(phone.Photo, fileName, new Size(104, 220));
            phone.Photo = Url.Content(thumbPath);

            HttpResponseMessage response;
            try
            {
                await _phonesService.CreatePhone(phone);
                response = Request.CreateResponse(HttpStatusCode.OK, phone.Photo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // PUT: api/Phones/5
        [Authorize(Roles = Constants.PrivilegedRole)]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] PhoneDto phone)
        {
            string fileName = Path.GetRandomFileName() + Constants.PhotoExtension;
            var thumbPath = ImagesProcessor.GetPhoneThumbnail(phone.Photo, fileName, new Size(104, 220));
            phone.Photo = Url.Content(thumbPath);

            HttpResponseMessage response;
            try
            {
                await _phonesService.UpdatePhone(id, phone);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // DELETE: api/Phones/5
        [Authorize(Roles = Constants.PrivilegedRole)]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response;
            try
            {
                await _phonesService.DeletePhone(id);
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