﻿using System;
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
    public class PhoneController : Controller
    {
        private IPhonePresentation _phonePresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Phones";

        public PhoneController(IPhonePresentation phonePresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _phonePresentation = phonePresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PhoneList(int page = 1)
        {
            var actionName = "PhoneList";
            var viewModels = _phonePresentation.GetList(CATEGORYNAME, actionName, page);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddNewPhone()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPhone(PhoneVm model)
        {
            _phonePresentation.GetAddNewOrEditPhoneAsync(model);

            return View("PhoneList");
        }

        [HttpGet]
        public IActionResult EditPhoneData(string modelName)
        {
            var phone = _phonePresentation.GetByModelName(modelName);

            return View(phone);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditPhoneAsync(PhoneVm model)
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
            var category = _categoryPresentation.GetByCategoryName("Phones");

            model.Category = category;

            _phonePresentation.GetAddNewOrEditPhoneAsync(model);
            return RedirectToAction("PhoneList");
        }

        public JsonResult RemovePhone(string modelName)
        {
            return Json(_phonePresentation.Remove(modelName));
        }
    }
}
