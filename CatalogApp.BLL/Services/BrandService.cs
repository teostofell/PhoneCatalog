using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class BrandService : BaseService, IBrandService
    {
        public BrandService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}


        public IEnumerable<BrandDTO> GetBrands()
        {
            var brands = unitOfWork.Brands.GetAll();
            return mapper.Map<List<BrandDTO>>(brands);
        }
    }
}
