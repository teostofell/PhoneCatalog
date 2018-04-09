using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public OrderItemService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderItem, OrderDTO>().ReverseMap();
            }).CreateMapper();
        }


        public OperationDetails AddToOrder(int orderId, OrderItemDTO item)
        {
            Db.Orders.Get(orderId).FirstOrDefault().OrderItems.Add(mapper.Map<OrderItem>(item));

            OperationDetails result = new OperationDetails(true, "Item added");

            return result;
        }

        public OperationDetails RemoveFromOrder(int orderItemId)
        {
            Db.OrderItems.Delete(orderItemId);

            OperationDetails result = new OperationDetails(true, "Item removed");

            return result;
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
