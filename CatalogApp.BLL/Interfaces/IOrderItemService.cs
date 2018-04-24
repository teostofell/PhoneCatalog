using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IOrderItemService
    {
        Task AddToOrder(OrderItemDto item);
        Task RemoveFromOrder(int orderItemId);
    }
}
