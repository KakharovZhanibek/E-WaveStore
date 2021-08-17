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
    public class LaptopController : Controller
    {
        private ILaptopPresentation _laptopPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Laptops";

        public LaptopController(ILaptopPresentation laptopPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _laptopPresentation = laptopPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }

        [HttpGet]
        public IActionResult AddNewLaptop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewLaptop(LaptopVM model)
        {
            _laptopPresentation.GetAddNewOrEditLaptopAsync(model);

            return View("LaptopList");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditLaptopAsync(LaptopVM model)
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
            var category = _categoryPresentation.GetByCategoryName("Laptops");

            model.Category = category;

            _laptopPresentation.GetAddNewOrEditLaptopAsync(model);
            return RedirectToAction("LaptopList");
        }
    }
}
