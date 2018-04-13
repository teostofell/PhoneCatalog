using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CatalogApp.BLL.Interfaces
{
    public interface ICitiesService : IDisposable
    {
        IEnumerable<CityDTO> GetCities();
    }
}