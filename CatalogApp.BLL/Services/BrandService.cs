using System;
using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CatalogApp.DAL.Entities;

namespace CatalogApp.BLL.Services
{
    public class BrandService : BaseService, IBrandService
    {
        public BrandService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}


        public IEnumerable<BrandDto> GetBrands()
        {
            IQueryable<Brand> brands;
            List<BrandDto> brandsDto;

            try
            {
                brands = UnitOfWork.Brands.GetAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            try
            {
                brandsDto = Mapper.Map<List<BrandDto>>(brands);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return brandsDto;
        }
    }
}
