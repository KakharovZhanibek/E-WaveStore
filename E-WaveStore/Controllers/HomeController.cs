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
using E_WaveStore.DataLayer.Repositories.Interfaces;

namespace E_WaveStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ISpecificationRepository _specificationRepository;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, 
                             UserManager<User> userManager, ISpecificationRepository specificationRepository)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _specificationRepository = specificationRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            AddDefaultData defaultRoles = new AddDefaultData(_roleManager, _userManager, _specificationRepository);
            await defaultRoles.CreateRoles();
            await defaultRoles.AddAdmin();
            defaultRoles.CreateDefaultSpecification();
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
