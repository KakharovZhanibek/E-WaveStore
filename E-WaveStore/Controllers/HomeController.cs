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
using E_WaveStore.DataLayer;
using Microsoft.Extensions.Hosting;

namespace E_WaveStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHost _host;

        public HomeController(ILogger<HomeController> logger, IHost host = null)
        {
            _logger = logger;
            _host = host;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await SeedExtention.SeedAsync(_host);
            _logger.LogInformation("Test Log Message");
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
