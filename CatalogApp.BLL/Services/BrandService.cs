using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.BLL.Services
{
    public class BrandService : BaseService, IBrandService
    {
        public BrandService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}


        public IEnumerable<BrandDto> GetBrands()
        {
            var brands = UnitOfWork.Brands.GetAll();
            return Mapper.Map<List<BrandDto>>(brands);
        }
    }
}
