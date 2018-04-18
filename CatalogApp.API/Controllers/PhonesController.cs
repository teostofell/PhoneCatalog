using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.API.Utils;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class PhonesController : ApiController
    {
        private IPhonesService db;
        private IMapper mapper;

        public PhonesController(IPhonesService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        public async Task<HttpResponseMessage> Get([FromUri]FilterVM filter)
        {
            var filterModel = mapper.Map<FilterModel>(filter);

            var phones = mapper.Map<List<PhoneSummaryVM>>(db.GetPhones(filterModel, filter.ItemsOnPage, filter.Page));

            var response = Request.CreateResponse(HttpStatusCode.OK, phones);

            // Set headers for paging
            response.Headers.Add("X-Pages-Total-Count", db.TotalPages.ToString());
            response.Headers.Add("X-Items-Total-Count", db.TotalItems.ToString());

            return response;
        }

        // GET: api/Phones/id
        public async Task<HttpResponseMessage> Get(int id)
        {
            HttpResponseMessage response = null;

            PhoneDTO phone = db.GetPhone(id);

            response = Request.CreateResponse(HttpStatusCode.OK, phone);

            return response;
        }

        // GET: api/Phones/?search=*
        [HttpGet]
        public HttpResponseMessage Search(string search)
        {
            IEnumerable<PhoneDTO> phones = db.SearchPhones(search);

            var response = Request.CreateResponse(HttpStatusCode.OK, phones);

            return response;
        }

        // GET: api/Phones/?slug=*
        [HttpGet]
        public async Task<HttpResponseMessage> GetBySlug(string slug)
        {
            HttpResponseMessage response = null;

            PhoneDTO phone = db.GetPhone(slug);

            response = Request.CreateResponse(HttpStatusCode.OK, phone);

            return response;
        }



        // POST: api/Phones
        [Authorize(Roles = "admin")]
        public async Task<HttpResponseMessage> Post([FromBody]PhoneDTO phone)
        {
            HttpResponseMessage response = null;

            string fileName = Path.GetRandomFileName() + ".png";
            var thumbPath = ImagesProcessor.GetPhoneThumbnail(phone.Photo, fileName, new Size(104, 220));
            phone.Photo = Url.Content(thumbPath);

            var result = await db.CreatePhone(phone);

            if(result.isSucceed)
                response = Request.CreateResponse(HttpStatusCode.OK, phone.Photo);
            else
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");

            return response;
        }

        // PUT: api/Phones/5
        [Authorize(Roles = "admin")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody]PhoneDTO phone)
        {
            string fileName = Path.GetRandomFileName() + ".png";
            var thumbPath = ImagesProcessor.GetPhoneThumbnail(phone.Photo, fileName, new Size(104, 220));
            phone.Photo = Url.Content(thumbPath);

            var result = await db.UpdatePhone(id, phone);

            if(result.isSucceed)
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
        }

        // DELETE: api/Phones/5
        [Authorize(Roles="admin")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response = null;

            var result = await db.DeletePhone(id);

            if (result.isSucceed)
                response = Request.CreateResponse(HttpStatusCode.OK, result.Message);
            else
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);

            return response;
        }
    }
}
