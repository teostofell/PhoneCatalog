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
    public class BrandService : IBrandService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public BrandService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandDTO>();
            }).CreateMapper();
        }


        public IEnumerable<BrandDTO> GetBrands()
        {
            var brands = Db.Brands.GetAll();
            return mapper.Map<List<BrandDTO>>(brands);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
