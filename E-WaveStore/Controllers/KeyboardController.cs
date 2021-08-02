using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.DataLayer;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace E_WaveStore.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]*/
    public class KeyboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IKeyboardPresentation _keyboardPersentation;
        // private IWebHostEnvironment _webHostEnvironment;

        public KeyboardController(IKeyboardPresentation keyboardPersentation = null)
        {
            _keyboardPersentation = keyboardPersentation;
            // _webHostEnvironment = webHostEnvironment;
        }

       /* [HttpGet]
        public IActionResult KeyboardList(int page = 1)
        {
            var viewModels = _keyboardPersentation.GetKeyboardList(page);

            return View("KeyboardList", viewModels);
        }*/
    }
}
