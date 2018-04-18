using AutoMapper;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class BaseService : IDisposable
    {
        protected IUnitOfWork unitOfWork { get; set; }
        protected IMapper mapper;

        public BaseService(IUnitOfWork db, IMapper mapper)
        {
            unitOfWork = db;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
