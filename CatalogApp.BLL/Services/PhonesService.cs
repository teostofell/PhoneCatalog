using AutoMapper;
using CatalogApp.BLL.BusinessModel;
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
    public class PhonesService : IPhonesService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public PhonesService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Phone, PhoneDTO>();
            }).CreateMapper();
        }

        public IEnumerable<PhoneDTO> GetPhones(FilterModel filter)
        {
            filter.Filter(Db.Phones.GetAll());
            return mapper.Map<List<PhoneDTO>>(Db.Phones.GetAll().ToList());
        }
    }
}
