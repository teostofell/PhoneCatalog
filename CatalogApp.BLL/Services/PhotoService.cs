using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;

namespace CatalogApp.BLL.Services
{
    public class PhotoService : BaseService, IPhotoService
    {    
        public PhotoService(IUnitOfWork db, IMapper mapper) : base(db, mapper) { }


        public async Task<OperationDetails> AddPhonePhoto(int phoneId, string path)
        {
            Photo photo = new Photo() { PhoneId = phoneId, Path = path };
            unitOfWork.Photos.Create(photo);

            try
            {
                await unitOfWork.SaveAsync();
            }
            catch
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Image has been added");
        }


        public async Task<OperationDetails> SetProfileAvatar(string userId, string avatarPath)
        {
            var profile = unitOfWork.ProfileManager.Get(userId).FirstOrDefault();
            profile.Avatar = avatarPath;

            unitOfWork.ProfileManager.Update(profile);

            try
            {
                await unitOfWork.SaveAsync();
                return new OperationDetails(true, "Avatar has been changed");
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

        }


        public IEnumerable<PhotoDTO> GetPhonePhotos(int phoneId)
        {
            var photos = unitOfWork.Photos.GetAll().Where(p => p.PhoneId == phoneId);
            return mapper.Map<List<PhotoDTO>>(photos);

        }

        public async Task<OperationDetails> DeletePhonePhoto(int photoId)
        {
            unitOfWork.Photos.Delete(photoId);

            try
            {
                await unitOfWork.SaveAsync();
            }
            catch
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Image has been deleted");
        }
    }
}
