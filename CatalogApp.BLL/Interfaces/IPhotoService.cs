using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public interface IPhotoService
    {
        Task SetProfileAvatar(string userId, string avatarPath);
        Task AddPhonePhoto(int phoneId, string path);
        IEnumerable<PhotoDto> GetPhonePhotos(int phoneId);
        Task DeletePhonePhoto(int photoId);
    }
}
