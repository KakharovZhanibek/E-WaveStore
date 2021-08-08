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
    public class TvController : Controller
    {
        private ITvPresentation _tvPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private const string CATEGORYNAME = "Tvs";

        public TvController(ITvPresentation tvPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _tvPresentation = tvPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TvList(int page = 1)
        {
            var actionName = "TvList";
            var viewModels = _tvPresentation.GetList(CATEGORYNAME, actionName, page);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddNewTv()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewTv(TvVM model)
        {
            _tvPresentation.GetAddNewOrEditTvAsync(model);

            return View("TvList");
        }

        [HttpGet]
        public IActionResult EditTvData(string modelName)
        {
            var tv = _tvPresentation.GetByModelName(modelName);

            return View(tv);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditTvAsync(TvVM model)
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
            var category = _categoryPresentation.GetByCategoryName("Tvs");

            model.Category = category;

            _tvPresentation.GetAddNewOrEditTvAsync(model);
            return RedirectToAction("TvList");
        }

        public JsonResult RemoveTv(string modelName)
        {
            return Json(_tvPresentation.Remove(modelName));
        }
    }
}
