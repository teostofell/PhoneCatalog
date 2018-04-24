﻿using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
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
            var result = await _orderItemService.AddToOrder(_mapper.Map<OrderItemDto>(item));

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }

        // DELETE: api/OrderItems/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _orderItemService.RemoveFromOrder(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }
    }
}
