using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public async Task Register(UserDto user)
        {

            ApplicationUser appUser = await UnitOfWork.UserManager.FindByEmailAsync(user.Email);

            if(appUser == null)
            {
                appUser = new ApplicationUser() { Email = user.Email, UserName = user.Email };
                var result = await UnitOfWork.UserManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)
                    throw new Exception("Some internal error. Check your values.");

                await UnitOfWork.UserManager.AddToRoleAsync(appUser.Id, "User");

                UserProfile profile = new UserProfile() { Id = appUser.Id, Avatar = user.Avatar, Name = user.Name, CreateTime = DateTime.Now, CityId = user.CityId };

                UnitOfWork.ProfileManager.Create(profile);
                await UnitOfWork.SaveAsync();
            }
            throw new Exception("The emails already exist.");
        }

        public async Task<UserDto> FindUser(string userName, string password)
        {
            ApplicationUser user = await UnitOfWork.UserManager.FindAsync(userName, password);
            var userDto = Mapper.Map<UserDto>(user.UserProfile);
            userDto.Email = user.Email;

            return userDto;
        }

        public async Task<UserDto> FindUser(string email)
        {
            ApplicationUser user = await UnitOfWork.UserManager.FindByEmailAsync(email);

            var userDto = Mapper.Map<UserDto>(user.UserProfile);
            userDto.Email = user.Email;

            return userDto;
        }

        public async Task<string> GetRole(string id)
        {
            var roles = await UnitOfWork.UserManager.GetRolesAsync(id);
            return roles[0];
        }

        public List<UserDto> GetUsers()
        {
            var uu = UnitOfWork.UserManager.Users.ToList();            
            var profiles = UnitOfWork.ProfileManager.GetAll().Include(p => p.ApplicationUser).ToList();

            var users = Mapper.Map<List<UserDto>>(profiles);

            return users;
        }
    }
}
