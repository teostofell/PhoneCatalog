using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetOrders(string userId);
        IEnumerable<OrderItemDto> GetOrderItems(int orderId);
        Task<OperationDetails> CreateOrder(string userId);
        Task<OrderDto> GetActualOrder(string userId);
        Task<OperationDetails> CloseOrder(int orderId);
    }
}
