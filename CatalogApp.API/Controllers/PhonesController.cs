﻿using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                cfg.CreateMap<PhoneDTO, PhoneVM>();
                cfg.CreateMap<FilterVM, FilterModel>()
                     .ForMember(dest => dest.Brand, opts => opts.MapFrom(src => src.Brand.Where(b => b.Value).Select(b => b.Key).ToList()))
                    .ForMember(dest => dest.OS, opts => opts.MapFrom(src => src.OS.Where(o => o.Value).Select(o => o.Key).ToList()));
            }).CreateMapper();

        }

        // GET: api/Phones
        public HttpResponseMessage Get(string search)
        {
            IEnumerable<PhoneDTO> phones = db.SearchPhones(search);
        
            var response = Request.CreateResponse(HttpStatusCode.OK, phones);

            return response;
        }

        // GET: api/Phones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Phones
        public HttpResponseMessage Post([FromBody]FilterVM filter)
        {
            var filterModel = mapper.Map<FilterModel>(filter);

            var phones = mapper.Map<List<PhoneVM>>(db.GetPhones(filterModel, filter.ItemsOnPage, filter.Page));

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
