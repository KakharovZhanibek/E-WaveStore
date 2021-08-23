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
using Microsoft.Extensions.Hosting;
using DataLayer;

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

        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<IActionResult> IndexAsync()
        {
            await SeedExtention.SeedAsync(_host);
            _logger.LogInformation("You requested the Home Page.");
           
            return View();
        }

        /*[ResponseCache(CacheProfileName = "NoCaching")]*/
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
