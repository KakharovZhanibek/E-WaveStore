using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_WaveStore.Models;
using E_WaveStore.Services;
using E_WaveStore.DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication;

namespace E_WaveStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;
        private IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IUserRepository userRepository)
        {
            _logger = logger;
            _userService = userService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //==============================================================================

        [HttpGet]
        public IActionResult Login()
        {
            var url = Request.Query["ReturnUrl"];
            var viewModel = new LoginVM()
            {
                ReturnUrl = url
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userRepository.Login(viewModel.Email, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginVM.Email), "Не правильный логин или пароль");
                return View(viewModel);
            }

            var claimsPrincipal = _userService.GetClaimsPrincipal(user);
            await HttpContext.SignInAsync(claimsPrincipal);

            if (!string.IsNullOrEmpty(viewModel.ReturnUrl))
            {
                return Redirect(viewModel.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _userService.Save(viewModel);
            return RedirectToAction("Index", "Home");
        }
        //===========================================================================

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
