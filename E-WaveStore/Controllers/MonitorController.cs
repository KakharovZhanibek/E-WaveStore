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
    public class MonitorController : Controller
    {
        private IMonitorPresentation _monitorPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Monitors";

        public MonitorController(IMonitorPresentation monitorPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _monitorPresentation = monitorPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MonitorList(int page = 1)
        {
            var actionName = "MonitorList";
            var viewModels = _monitorPresentation.GetList(CATEGORYNAME, actionName, page);

            return View("MonitorList", viewModels);
        }

        [HttpGet]
        public IActionResult AddNewMonitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMonitor(MonitorVM model)
        {
            _monitorPresentation.GetAddNewOrEditMonitorAsync(model);

            return View("MonitorList");
        }

        [HttpGet]
        public IActionResult EditMonitorData(string modelName)
        {
            var monitor = _monitorPresentation.GetByModelName(modelName);

            return View(monitor);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditMonitorAsync(MonitorVM model)
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
            var category = _categoryPresentation.GetByCategoryName("Monitors");

            model.Category = category;

            _monitorPresentation.GetAddNewOrEditMonitorAsync(model);
            return RedirectToAction("MonitorList");
        }

        public JsonResult RemoveMonitor(string modelName)
        {
            return Json(_monitorPresentation.Remove(modelName));
        }
    }
}
