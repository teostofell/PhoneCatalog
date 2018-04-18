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
    public class CitiesService : BaseService, ICitiesService
    {
        public CitiesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<CityDTO> GetCities()
        {
            var cities = unitOfWork.Cities.GetAll();
            return mapper.Map<List<CityDTO>>(cities);
        }

    }
}
