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
    public class OSService : IOSService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public OSService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OS, OSDTO>();
            }).CreateMapper();
        }

        public IEnumerable<OSDTO> GetOS()
        {
            var os = Db.OperatingSystems.GetAll();
            return mapper.Map<List<OSDTO>>(os);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
