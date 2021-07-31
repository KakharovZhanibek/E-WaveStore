using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_WaveStore.Controllers
{
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

        public IActionResult KeyboardList(int page = 1)
        {
            var viewModels = _keyboardPersentation.GetKeyboardList(page);

            return View("KeyboardList", viewModels);
        }
    }
}
