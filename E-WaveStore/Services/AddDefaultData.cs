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
        

        public AddDefaultData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;            
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
        }
    }
}
