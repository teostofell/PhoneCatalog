using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.DAL.Interfaces;

namespace CatalogApp.BLL.Services
{
    class PhotoService : IPhotoService
    {
        public IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public PhotoService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                
            }).CreateMapper();
        }


        public Task<OperationDetails> AddPhonePhoto(int phoneId)
        {
            throw new NotImplementedException();
        }


        public Task<OperationDetails> SetPhonePhoto(int phoneId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> SetProfileAvatar(int userId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}
