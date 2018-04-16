using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public interface IPhotoService : IDisposable
    {
        Task<OperationDetails> SetProfileAvatar(string userId, string avatarPath);
        Task<OperationDetails> AddPhonePhoto(int phoneId, string path);
        IEnumerable<PhotoDTO> GetPhonePhotos(int phoneId);
        Task<OperationDetails> DeletePhonePhoto(int photoId);
    }
}
