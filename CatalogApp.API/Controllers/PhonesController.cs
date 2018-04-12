using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.BusinessModel;
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
    public class PhonesController : ApiController
    {
        private IPhonesService db;
        private IMapper mapper;

        public PhonesController(IPhonesService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<PhoneDTO, PhoneSummaryVM>();
                //cfg.CreateMap<FilterVM, FilterModel>()
                //     .ForMember(dest => dest.Brand, opts => opts.MapFrom(src => src.Brand.Where(b => b.Value).Select(b => b.Key).ToList()))
                //    .ForMember(dest => dest.OS, opts => opts.MapFrom(src => src.OS.Where(o => o.Value).Select(o => o.Key).ToList()));
            }).CreateMapper();

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
        public HttpResponseMessage Post([FromBody]FilterVM filter)
        {
            var filterModel = mapper.Map<FilterModel>(filter);

            var phones = mapper.Map<List<PhoneSummaryVM>>(db.GetPhones(filterModel, filter.ItemsOnPage, filter.Page));

            var response = Request.CreateResponse(HttpStatusCode.OK, phones);

            // Set headers for paging
            response.Headers.Add("X-Pages-Total-Count", db.TotalPages.ToString());
            response.Headers.Add("X-Items-Total-Count", db.TotalItems.ToString());

            return response;
        }

        // PUT: api/Phones/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Phones/5
        public void Delete(int id)
        {
        }
    }
}
