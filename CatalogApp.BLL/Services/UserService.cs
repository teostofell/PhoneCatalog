using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;        

        public UserService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserDTO>();
            }).CreateMapper();
        }

        public async Task<OperationDetails> Register(UserDTO user)
        {
            ApplicationUser appUser = await Db.UserManager.FindByEmailAsync(user.Email);

            if(appUser == null)
            {
                appUser = new ApplicationUser() { Email = user.Email, UserName = user.Email };
                var result = await Db.UserManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)
                    return new OperationDetails(false, "Some internal error. Check your values.");

                await Db.UserManager.AddToRoleAsync(appUser.Id, "User");

                UserProfile profile = new UserProfile() { Id = appUser.Id, Avatar = user.Avatar, Name = user.Name, CreateTime = DateTime.Now, CityId = user.CityId };

                Db.ProfileManager.Create(profile);
                await Db.SaveAsync();
                return new OperationDetails(true, $"User registered succesfully. Id - {appUser.Id}");
            }
            return new OperationDetails(false, "The emails already exist.");
        }

        public async Task<UserDTO> FindUser(string userName, string password)
        {
            ApplicationUser user = await Db.UserManager.FindAsync(userName, password);
            var userDTO = mapper.Map<UserDTO>(user.UserProfile);
            userDTO.Email = user.Email;

            return userDTO;
        }

        public async Task<UserDTO> FindUser(string email)
        {
            ApplicationUser user = await Db.UserManager.FindByEmailAsync(email);

            var userDTO = mapper.Map<UserDTO>(user.UserProfile);
            userDTO.Email = user.Email;

            return userDTO;
        }

        public async Task<string> GetRole(string id)
        {
            var roles = await Db.UserManager.GetRolesAsync(id);
            return roles[0];
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
