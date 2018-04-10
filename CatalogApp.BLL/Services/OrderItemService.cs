using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                cfg.CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            }).CreateMapper();
        }


        public async Task<OperationDetails> AddToOrder(OrderItemDTO item)
        {
            Order order = await Db.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            OrderItem orderItem = new OrderItem() { OrderId = item.OrderId, PhoneId = item.Phone.Id, Quantity = item.Quantity };

            orderItem = Db.OrderItems.Create(orderItem);

            OperationDetails result = new OperationDetails(true, "Item added");

            await Db.SaveAsync();

            return result;
        }

        public async Task<OperationDetails> RemoveFromOrder(int orderItemId)
        {
            Db.OrderItems.Delete(orderItemId);

            OperationDetails result = new OperationDetails(true, "Item removed");

            await Db.SaveAsync();

            return result;
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
