using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class BrandsController : ApiController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService context, IMapper mapper)
        {
            _brandService = context;
            _mapper = mapper;
        }

        // GET: api/Brands
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var brands = _brandService.GetBrands();
                var brandsVm = _mapper.Map<List<BrandViewModel>>(brands);
                response = Request.CreateResponse(HttpStatusCode.OK, brandsVm);
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
