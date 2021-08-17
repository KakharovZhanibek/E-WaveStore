using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_WaveStore.Controllers
{
    public class SmartWatchController : Controller
    {
        private ISmartWatchPresentation _smartWatchPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "SmartWatches";

        public SmartWatchController(ISmartWatchPresentation smartWatchPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _smartWatchPresentation = smartWatchPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }

        [HttpGet]
        public IActionResult AddNewSmartWatch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSmartWatch(SmartWatchVM model)
        {
            _smartWatchPresentation.GetAddNewOrEditSmartWatchAsync(model);

            return View("SmartWatchList");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditSmartWatchAsync(SmartWatchVM model)
        {
            if (model.ImgFile != null)
            {
                var fileExtention = Path.GetExtension(model.ImgFile.FileName);
                var fileName = $"{model.ModelName.Substring(4)}{fileExtention}";
                var path = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "Images", "ProductImages", fileName);
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await model.ImgFile.CopyToAsync(fileStream);
                }
                model.ImgUrl = $"/Images/ProductImages/{fileName}";
            }
            var category = _categoryPresentation.GetByCategoryName("SmartWatches");

            model.Category = category;

            _smartWatchPresentation.GetAddNewOrEditSmartWatchAsync(model);
            return RedirectToAction("SmartWatchList");
        }
    }
}
