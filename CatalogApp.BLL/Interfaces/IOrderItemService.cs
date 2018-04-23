using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IOrderItemService
    {
        Task<OperationDetails> AddToOrder(OrderItemDto item);
        Task<OperationDetails> RemoveFromOrder(int orderItemId);
    }
}
