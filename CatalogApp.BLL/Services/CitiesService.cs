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
    public class CitiesService : BaseService, ICitiesService
    {
        public CitiesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<CityDto> GetCities()
        {
            IQueryable<City> cities;
            List<CityDto> citiesDto;

            try
            {
                cities = UnitOfWork.Cities.GetAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            try
            {
                citiesDto = Mapper.Map<List<CityDto>>(cities);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return citiesDto;
        }

    }
}
