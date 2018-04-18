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
    public class ScreenResolutionService : IScreenResolutionService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public ScreenResolutionService(IUnitOfWork db, IMapper mapper)
        {
            Db = db;
            this.mapper = mapper;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScreenResolution, ScreenResolutionDTO>();
            }).CreateMapper();
        }

        public IEnumerable<ScreenResolutionDTO> GetScreenResolutions()
        {
            var resolutions = Db.ScreenResolutions.GetAll();
            return mapper.Map<List<ScreenResolutionDTO>>(resolutions);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
