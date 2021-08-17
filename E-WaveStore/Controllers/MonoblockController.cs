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
    public class MonoblockController : Controller
    {
        private IMonoblockPresentation _monoblockPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Monoblocks";
        public MonoblockController(IMonoblockPresentation monoblockPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _monoblockPresentation = monoblockPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }

        [HttpGet]
        public IActionResult AddNewMonoblock()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMonoblock(MonoBlockVM model)
        {
            _monoblockPresentation.GetAddNewOrEditMonoblockAsync(model);

            return View("MonoblockList");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditMonoblockAsync(MonoBlockVM model)
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
            var category = _categoryPresentation.GetByCategoryName("Monoblocks");

            model.Category = category;

            _monoblockPresentation.GetAddNewOrEditMonoblockAsync(model);
            return RedirectToAction("MonoblockList");
        }
    }
}
