using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Linq;

namespace CatalogApp.BLL.Services
{
    public class FiltersService : BaseService, IFiltersService
    {       
        public FiltersService(IUnitOfWork db, IMapper mapper) :base(db, mapper) {}

        public FilterModel GetFilterValues()
        {
            FilterModel filter = new FilterModel();

            filter.Brand = UnitOfWork.Brands.GetAll().Select(b => b.Slug).ToList();
            filter.Os = UnitOfWork.OperatingSystems.GetAll().Select(o => o.Slug).ToList();
            filter.Price = new Range<decimal>();
            filter.Storage = new Range<int>();

            return filter;
        }
    }
}
