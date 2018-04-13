using CatalogApp.BLL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public interface IPhotoService : IDisposable
    {
        Task<OperationDetails> SetPhonePhoto(int phoneId);
        Task<OperationDetails> SetProfileAvatar(int userId);
        Task<OperationDetails> AddPhonePhoto(int phoneId);
    }
}
