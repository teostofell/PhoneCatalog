using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.BLL.Services
{
    public class CitiesService : BaseService, ICitiesService
    {
        public CitiesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<CityDto> GetCities()
        {
            var cities = UnitOfWork.Cities.GetAll();
            return Mapper.Map<List<CityDto>>(cities);
        }

    }
}
