using E_WaveStore.DataLayer.Models;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Services
{
    public class AddDefaultData
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ISpecificationRepository _specificationRepository;

        public AddDefaultData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ISpecificationRepository specificationRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _specificationRepository = specificationRepository;
        }

        public async Task CreateRoles()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("manager"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }
        }

        public async Task AddAdmin()
        {
            if (!_userManager.Users.Any())
            {
                User user = new User { Email = "admin@gmail.com", UserName = "admin" };

                await _userManager.CreateAsync(user, "admin");
                await _userManager.AddToRoleAsync(user, "admin");
            }
        }

        public void CreateDefaultSpecification()
        {

            KeyboardVM keyboard_1 = new KeyboardVM
            {
                KeysAmount = 112,
                ConnectionType = "Wired",
                Layout = "qwerty",
                Dimension = "44.2 x 4.9 x 13.2",
                KeyType = "Mechanical",
                Color = "Black",
                BackLight = "RGB"
            };
            string JSONString_1 = string.Empty;
            JSONString_1 = JsonConvert.SerializeObject(keyboard_1);
           /* _specificationRepository.Save(
                new Specification
                {
                    Characteristics = JSONString_1
                });*/
            /*
                KeyboardVM keyboard_2 = new KeyboardVM
                {
                    KeysAmount = 112,
                    ConnectionType = "Wireless",
                    Layout = "qwerty",
                    Dimension = "44.4 x 3.7 x 13.2",
                    KeyType = "Mechanical",
                    Color = "Black",
                    BackLight = "RGB"
                };

                KeyboardVM keyboard_3 = new KeyboardVM
                {
                    KeysAmount = 112,
                    ConnectionType = "Wireless",
                    Layout = "qwerty",
                    Dimension = "44.4 x 3.7 x 13.2",
                    KeyType = "optic-mechanical",
                    Color = "Black",
                    BackLight = "Red"
                };

                KeyboardVM keyboard_4 = new KeyboardVM
                {
                    KeysAmount = 117,
                    ConnectionType = "Wireless",
                    Layout = "qwerty",
                    Dimension = "37.3 x 2.1 x 14.4",
                    KeyType = "membrane",
                    Color = "Black",
                    BackLight = "Blue"
                };          
            KeyboardVM keyboard_5 = new KeyboardVM
            {
                KeysAmount = 107,
                ConnectionType = "Wired",
                Layout = "qwerty",
                Dimension = "46.3 x 15.6 x 4.2",
                KeyType = "membrane",
                Color = "Black",
                BackLight = "RGB"
            };*/
            /*
           string JSONString_1 = string.Empty

                   string JSONString_2 = string.Empty;
                   string JSONString_3 = string.Empty;
                   string JSONString_4 = string.Empty;
           string JSONString_5 = string.Empty;*/

            /* JSONString_1 = JsonConvert.SerializeObject(keyboard_1);           
            JSONString_2 = JsonConvert.SerializeObject(keyboard_2);
            JSONString_3 = JsonConvert.SerializeObject(keyboard_3);
            JSONString_4 = JsonConvert.SerializeObject(keyboard_4);
            JSONString_5 = JsonConvert.SerializeObject(keyboard_5);*/

            /*
            _specificationRepository.Save(
                new Specification
                {
                    Characteristics = JSONString_1
                });
            
             _specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_2
                 });
             _specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_3
                 });
             _specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_4
                 });

            _specificationRepository.Save(
               new Specification
               {
                   Characteristics = JSONString_5
               });*/
        }
    }
}
