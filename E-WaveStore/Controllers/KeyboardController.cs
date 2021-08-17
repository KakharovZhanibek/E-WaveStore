﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.DataLayer;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace E_WaveStore.Controllers
{
    public class KeyboardController : Controller
    {
        private IKeyboardPresentation _keyboardPersentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Keyboards";

        public KeyboardController(IKeyboardPresentation keyboardPersentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _keyboardPersentation = keyboardPersentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }

        [HttpGet]
        public IActionResult AddNewKeyboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewKeyboard(KeyboardVM model)
        {
            _keyboardPersentation.GetAddNewOrEditKeyboardAsync(model);

            return View("KeyboardList");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditKeyboardAsync(KeyboardVM model)
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
            var category = _categoryPresentation.GetByCategoryName(CATEGORYNAME);

            model.Category = category;

            _keyboardPersentation.GetAddNewOrEditKeyboardAsync(model);
            return RedirectToAction("KeyboardList");
        }
    }
}
