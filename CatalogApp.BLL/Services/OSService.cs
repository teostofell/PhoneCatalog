using System;
using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CatalogApp.DAL.Entities;

namespace CatalogApp.BLL.Services
{
    public class OsService : BaseService, IOsService
    {
        public OsService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<OsDto> GetOs()
        {
            IQueryable<Os> os;
            List<OsDto> osDto;
            try
            {
                os = UnitOfWork.OperatingSystems.GetAll();
                osDto = Mapper.Map<List<OsDto>>(os);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return osDto;
        }

    }
}
