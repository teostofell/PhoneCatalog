using System;
using System.Collections.Generic;
using System.Linq;
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
            UnitOfWork.Photos.Create(photo);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Image has been added");
        }


        public async Task<OperationDetails> SetProfileAvatar(string userId, string avatarPath)
        {
            var profile = UnitOfWork.ProfileManager.Get(userId).FirstOrDefault();
            profile.Avatar = avatarPath;

            UnitOfWork.ProfileManager.Update(profile);

            try
            {
                await UnitOfWork.SaveAsync();
                return new OperationDetails(true, "Avatar has been changed");
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

        }


        public IEnumerable<PhotoDto> GetPhonePhotos(int phoneId)
        {
            var photos = UnitOfWork.Photos.GetAll().Where(p => p.PhoneId == phoneId);
            return Mapper.Map<List<PhotoDto>>(photos);

        }

        public async Task<OperationDetails> DeletePhonePhoto(int photoId)
        {
            UnitOfWork.Photos.Delete(photoId);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Image has been deleted");
        }
    }
}
