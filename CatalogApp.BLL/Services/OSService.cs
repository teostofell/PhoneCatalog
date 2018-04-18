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
    public class OSService : BaseService, IOSService
    {
        public OSService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<OSDTO> GetOS()
        {
            var os = unitOfWork.OperatingSystems.GetAll();
            return mapper.Map<List<OSDTO>>(os);
        }

    }
}
