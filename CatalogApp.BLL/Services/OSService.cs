using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.BLL.Services
{
    public class OsService : BaseService, IOsService
    {
        public OsService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<Osdto> GetOs()
        {
            var os = UnitOfWork.OperatingSystems.GetAll();
            return Mapper.Map<List<Osdto>>(os);
        }

    }
}
