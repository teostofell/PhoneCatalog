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
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public async Task<OperationDetails> Register(UserDTO user)
        {
            ApplicationUser appUser = await unitOfWork.UserManager.FindByEmailAsync(user.Email);

            if(appUser == null)
            {
                appUser = new ApplicationUser() { Email = user.Email, UserName = user.Email };
                var result = await unitOfWork.UserManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)
                    return new OperationDetails(false, "Some internal error. Check your values.");

                await unitOfWork.UserManager.AddToRoleAsync(appUser.Id, "User");

                UserProfile profile = new UserProfile() { Id = appUser.Id, Avatar = user.Avatar, Name = user.Name, CreateTime = DateTime.Now, CityId = user.CityId };

                unitOfWork.ProfileManager.Create(profile);
                await unitOfWork.SaveAsync();
                return new OperationDetails(true, $"User registered succesfully. Id - {appUser.Id}");
            }
            return new OperationDetails(false, "The emails already exist.");
        }

        public async Task<UserDTO> FindUser(string userName, string password)
        {
            ApplicationUser user = await unitOfWork.UserManager.FindAsync(userName, password);
            var userDTO = mapper.Map<UserDTO>(user.UserProfile);
            userDTO.Email = user.Email;

            return userDTO;
        }

        public async Task<UserDTO> FindUser(string email)
        {
            ApplicationUser user = await unitOfWork.UserManager.FindByEmailAsync(email);

            var userDTO = mapper.Map<UserDTO>(user.UserProfile);
            userDTO.Email = user.Email;

            return userDTO;
        }

        public async Task<string> GetRole(string id)
        {
            var roles = await unitOfWork.UserManager.GetRolesAsync(id);
            return roles[0];
        }

        public List<UserDTO> GetUsers()
        {
            var uu = unitOfWork.UserManager.Users.ToList();            
            var profiles = unitOfWork.ProfileManager.GetAll().Include(p => p.ApplicationUser).ToList();

            var users = mapper.Map<List<UserDTO>>(profiles);

            return users;
        }
    }
}
