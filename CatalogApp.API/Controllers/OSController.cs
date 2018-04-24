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
    public class OsController : ApiController
    {
        private readonly IOsService _osService;
        private readonly IMapper _mapper;

        public OsController(IOsService context, IMapper mapper)
        {
            _osService = context;
            _mapper = mapper;
        }

        // GET: api/OS
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var os = _osService.GetOs();
                var osVm = _mapper.Map<List<OsViewModel>>(os);
                response = Request.CreateResponse(HttpStatusCode.OK, osVm);
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
