using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService context, IMapper mapper)
        {
            _ordersService = context;
            _mapper = mapper;
        }

        // GET: api/Orders/5
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;

            try
            {
                var result = _ordersService.GetOrders(id);

                var resultVm = _mapper.Map<List<OrderViewModel>>(result);

                response = Request.CreateResponse(HttpStatusCode.OK, resultVm);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActualOrder(string userId)
        {
            HttpResponseMessage response;
            try
            {
                var result = await _ordersService.GetActualOrder(userId);
                response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<OrderViewModel>(result));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // POST: api/Orders
        public async Task<HttpResponseMessage> Post([FromBody] string userId)
        {
            HttpResponseMessage response;
            try
            {
                await _ordersService.CreateOrder(userId);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // DELETE: api/Orders/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response;
            try
            {
                await _ordersService.CloseOrder(id);
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