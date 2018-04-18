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
    public class OrderItemService : BaseService, IOrderItemService
    {
        public OrderItemService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}


        public async Task<OperationDetails> AddToOrder(OrderItemDTO item)
        {

            OrderItem orderItem = new OrderItem() { OrderId = item.OrderId, PhoneId = item.Phone.Id, Quantity = item.Quantity };

            Order order = await unitOfWork.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            order.Total += item.Phone.Price * item.Quantity;
            unitOfWork.Orders.Update(order);

            var temp = unitOfWork.OrderItems.GetAll().Where(oi => (oi.OrderId == item.OrderId && oi.PhoneId == item.Phone.Id));

            if (temp.FirstOrDefault() != null)
            {
                temp.Single().Quantity += item.Quantity;

                OperationDetails resultUpdated = new OperationDetails(true, "Item's quantity changed");

                await unitOfWork.SaveAsync();

                return resultUpdated;
            }

            orderItem = unitOfWork.OrderItems.Create(orderItem);

            OperationDetails resultAdded = new OperationDetails(true, "Item added");

            await unitOfWork.SaveAsync();

            return resultAdded;
        }

        public async Task<OperationDetails> RemoveFromOrder(int orderItemId)
        {
            OrderItem item = await unitOfWork.OrderItems.Get(orderItemId).Include(oi => oi.Phone).FirstOrDefaultAsync();
            Order order = await unitOfWork.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            order.Total -= item.Phone.Price * item.Quantity;
            unitOfWork.Orders.Update(order);

            unitOfWork.OrderItems.Delete(orderItemId);

            OperationDetails result = new OperationDetails(true, "Item removed");

            await unitOfWork.SaveAsync();

            return result;
        }
    }
}
