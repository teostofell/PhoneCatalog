using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IPhonesService : IDisposable
    {
        int TotalPages { get; set; }
        int TotalItems { get; set; }
        IEnumerable<PhoneDTO> GetPhones(FilterModel filter = null, int itemsOnPage = 0, int page = 1);
        PhoneDTO GetPhone(int id);
        IEnumerable<PhoneDTO> SearchPhones(string searchString);
    }
}
