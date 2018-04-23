using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public interface IPhotoService
    {
        Task<OperationDetails> SetProfileAvatar(string userId, string avatarPath);
        Task<OperationDetails> AddPhonePhoto(int phoneId, string path);
        IEnumerable<PhotoDto> GetPhonePhotos(int phoneId);
        Task<OperationDetails> DeletePhonePhoto(int photoId);
    }
}
