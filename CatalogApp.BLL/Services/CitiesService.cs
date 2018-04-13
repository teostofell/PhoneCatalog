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
    public class CitiesService : ICitiesService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public CitiesService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDTO>();
            }).CreateMapper();
        }

        public IEnumerable<CityDTO> GetCities()
        {
            var cities = Db.Cities.GetAll();
            return mapper.Map<List<CityDTO>>(cities);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
