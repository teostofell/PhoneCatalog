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
    public class ScreenResolutionService : BaseService, IScreenResolutionService
    {
        public ScreenResolutionService(IUnitOfWork db, IMapper mapper) : base(db, mapper) { }

        public IEnumerable<ScreenResolutionDTO> GetScreenResolutions()
        {
            var resolutions = unitOfWork.ScreenResolutions.GetAll();
            return mapper.Map<List<ScreenResolutionDTO>>(resolutions);
        }
    }
}
