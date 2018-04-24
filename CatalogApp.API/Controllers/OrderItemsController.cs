using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OrderItemsController : ApiController
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemService context, IMapper mapper)
        {
            _orderItemService = context;
            _mapper = mapper;
        }

        // POST: api/OrderItems
        public async Task<HttpResponseMessage> Post([FromBody]OrderItemViewModel item)
        {
            HttpResponseMessage response;
            try
            {
                await _orderItemService.AddToOrder(_mapper.Map<OrderItemDto>(item));
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        // DELETE: api/OrderItems/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response;

            try
            {
                await _orderItemService.RemoveFromOrder(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
            return response;
        }
    }
}
