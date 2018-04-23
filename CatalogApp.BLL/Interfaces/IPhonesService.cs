using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IPhonesService
    {
        int TotalPages { get; set; }
        int TotalItems { get; set; }
        IEnumerable<PhoneDto> GetPhones(FilterModel filter = null, int itemsOnPage = 0, int page = 1);
        PhoneDto GetPhone(int id);
        PhoneDto GetPhone(string slug);
        IEnumerable<PhoneDto> SearchPhones(string searchString);
        Task<OperationDetails> CreatePhone(PhoneDto phoneDto);
        Task<OperationDetails> UpdatePhone(int id, PhoneDto phone);
        Task<OperationDetails> DeletePhone(int id);
    }
}
