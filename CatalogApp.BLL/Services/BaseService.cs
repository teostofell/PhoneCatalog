using AutoMapper;
using CatalogApp.DAL.Interfaces;
using System;
using System.Diagnostics;

namespace CatalogApp.BLL.Services
{
    public class BaseService : IDisposable
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected readonly IMapper Mapper;

        protected BaseService(IUnitOfWork db, IMapper mapper)
        {
            UnitOfWork = db;
            Mapper = mapper;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
