using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class PhonesService : IPhonesService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PhonesService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Phone, PhoneDTO>();
            }).CreateMapper();
        }

        public IEnumerable<PhoneDTO> GetPhones(FilterModel filter, int itemsOnPage, int page)
        {
            var phones = Filter(filter);
            phones = Paginate(phones, itemsOnPage, page);

            return mapper.Map<List<PhoneDTO>>(phones);
        }

        private IEnumerable<Phone> Filter(FilterModel filter)
        {
            if (filter == null)
                return Db.Phones.GetAll();

            //decimal fromPrice = filter.Price?["From"] ?? 0, toPrice = filter.Price?["To"] ?? 9999;
            //var phones = Db.Phones.GetAll().Include(p => p.Brand)
            //    .Include(p => p.OS)
            //    .Where(p => filter.Brand.Contains(p.Brand.Slug))
            //    .Where(p => filter.OS.Contains(p.OS.Slug))
            //    .Where(p => (p.Price >= fromPrice && p.Price <= toPrice));

            var phones = Db.Phones.GetAll().Include(p => p.Brand)
                .Include(p => p.OS)
                .Where(p => filter.Brand.Contains(p.Brand.Slug))
                .Where(p => filter.OS.Contains(p.OS.Slug));

            return phones.ToList();
        }

        private IEnumerable<Phone> Paginate(IEnumerable<Phone> phones, int itemsOnPage, int page)
        {
            if (itemsOnPage == 0)
            {
                TotalPages = 1;
                return phones;
            }

            TotalItems = phones.Count();
            TotalPages = Convert.ToInt32(Math.Ceiling(((double)phones.Count() / itemsOnPage)));

            return phones.Skip((page - 1) * itemsOnPage).Take(itemsOnPage);
        }
    }
}
