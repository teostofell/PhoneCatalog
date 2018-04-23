using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.BLL.Services
{
    public class ScreenResolutionService : BaseService, IScreenResolutionService
    {
        public ScreenResolutionService(IUnitOfWork db, IMapper mapper) : base(db, mapper) { }

        public IEnumerable<ScreenResolutionDto> GetScreenResolutions()
        {
            var resolutions = UnitOfWork.ScreenResolutions.GetAll();
            return Mapper.Map<List<ScreenResolutionDto>>(resolutions);
        }
    }
}
