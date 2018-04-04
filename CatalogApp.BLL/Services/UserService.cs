using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            }).CreateMapper();
        }

        public async Task Register(UserDTO user)
        {
            ApplicationUser appUser = await Db.UserManager.FindByEmailAsync(user.Email);

            if(appUser == null)
            {
                appUser = new ApplicationUser() { Email = user.Email, UserName = user.Email };
                var result = await Db.UserManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                    Debug.WriteLine("User had been created");

                UserProfile profile = new UserProfile() { Id = appUser.Id, Avatar = user.Avatar, Name = user.Name, CreateTime = DateTime.Now, CityId = 1 };

                Db.ProfileManager.Create(profile);
                await Db.SaveAsync();
            }

        }
    }
}
