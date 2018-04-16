using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class FiltersService : IFiltersService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public FiltersService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                
            }).CreateMapper();
        }

        public FilterModel GetFilterValues()
        {
            FilterModel filter = new FilterModel();

            filter.Brand = Db.Brands.GetAll().Select(b => b.Slug).ToList();
            filter.OS = Db.OperatingSystems.GetAll().Select(o => o.Slug).ToList();
            filter.Price = new Range<decimal>();
            filter.Storage = new Range<int>();

            return filter;
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
