using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public PhotoService(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }


        public async Task AddPhonePhoto(int phoneId, string path)
        {
            Photo photo = new Photo() {PhoneId = phoneId, Path = path};

            try
            {
                UnitOfWork.Photos.Create(photo);
                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }


        public async Task SetProfileAvatar(string userId, string avatarPath)
        {
            UserProfile profile;
            try
            {
                profile = UnitOfWork.ProfileManager.Get(userId).FirstOrDefault();

                profile.Avatar = avatarPath;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            try
            {
                UnitOfWork.ProfileManager.Update(profile);
                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }


        public IEnumerable<PhotoDto> GetPhonePhotos(int phoneId)
        {
            var photos = UnitOfWork.Photos.GetAll().Where(p => p.PhoneId == phoneId);
            return Mapper.Map<List<PhotoDto>>(photos);
        }

        public async Task DeletePhonePhoto(int photoId)
        {
            try
            {
                UnitOfWork.Photos.Delete(photoId);
                await UnitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}