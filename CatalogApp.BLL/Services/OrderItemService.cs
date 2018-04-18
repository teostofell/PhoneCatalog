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

        public OrderItemService(IUnitOfWork db, IMapper mapper)
        {
            Db = db;
            this.mapper = mapper;
        }


        public async Task<OperationDetails> AddToOrder(OrderItemDTO item)
        {

            OrderItem orderItem = new OrderItem() { OrderId = item.OrderId, PhoneId = item.Phone.Id, Quantity = item.Quantity };

            Order order = await Db.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            order.Total += item.Phone.Price * item.Quantity;
            Db.Orders.Update(order);

            var temp = Db.OrderItems.GetAll().Where(oi => (oi.OrderId == item.OrderId && oi.PhoneId == item.Phone.Id));

            if (temp.FirstOrDefault() != null)
            {
                temp.Single().Quantity += item.Quantity;

                OperationDetails resultUpdated = new OperationDetails(true, "Item's quantity changed");

                await Db.SaveAsync();

                return resultUpdated;
            }

            orderItem = Db.OrderItems.Create(orderItem);

            OperationDetails resultAdded = new OperationDetails(true, "Item added");

            await Db.SaveAsync();

            return resultAdded;
        }

        public async Task<OperationDetails> RemoveFromOrder(int orderItemId)
        {
            OrderItem item = await Db.OrderItems.Get(orderItemId).Include(oi => oi.Phone).FirstOrDefaultAsync();
            Order order = await Db.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            order.Total -= item.Phone.Price * item.Quantity;
            Db.Orders.Update(order);

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
