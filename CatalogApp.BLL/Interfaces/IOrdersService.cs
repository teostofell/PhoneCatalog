using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDTO> GetOrders(string userId);
        IEnumerable<OrderItemDTO> GetOrderItems(int orderId);
        Task<OperationDetails> CreateOrder(string userId);
        Task<OrderDTO> GetActualOrder(string userId);
    }
}
