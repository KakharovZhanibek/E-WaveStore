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
    public class MouseController : Controller
    {
        private IMousePresentation _mousePresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Mice";

        public MouseController(IMousePresentation mousePresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _mousePresentation = mousePresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }

        [HttpGet]
        public IActionResult AddNewMouse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMouse(MouseVM model)
        {
            _mousePresentation.GetAddNewOrEditMouseAsync(model);

            return View("MouseList");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditMouseAsync(MouseVM model)
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
            var category = _categoryPresentation.GetByCategoryName("Mouses");

            model.Category = category;

            _mousePresentation.GetAddNewOrEditMouseAsync(model);
            return RedirectToAction("MouseList");
        }
    }
}
