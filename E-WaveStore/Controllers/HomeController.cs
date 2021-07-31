using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_WaveStore.Models;
using Microsoft.AspNetCore.Authorization;
using E_WaveStore.Services;
using Microsoft.AspNetCore.Identity;
using E_WaveStore.DataLayer.Models;

namespace E_WaveStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager = null, UserManager<User> userManager = null)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            AddDefaultRolesAndAdmin defaultRoles = new AddDefaultRolesAndAdmin(_roleManager, _userManager);
            await defaultRoles.CreateRoles();
            await defaultRoles.AddAdmin();
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
