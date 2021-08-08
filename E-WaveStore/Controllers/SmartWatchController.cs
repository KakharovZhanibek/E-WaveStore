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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SmartWatchList(int page = 1)
        {
            var actionName = "SmartWatchList";
            var viewModels = _smartWatchPresentation.GetList(CATEGORYNAME, actionName, page);

            return View(viewModels);
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

        [HttpGet]
        public IActionResult EditSmartWatchData(string modelName)
        {
            var smartWatch = _smartWatchPresentation.GetByModelName(modelName);

            return View(smartWatch);
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

        public JsonResult RemoveSmartWatch(string modelName)
        {
            return Json(_smartWatchPresentation.Remove(modelName));
        }
    }
}
