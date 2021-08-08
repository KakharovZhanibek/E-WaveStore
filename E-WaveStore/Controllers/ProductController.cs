using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace E_WaveStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductPresentation<ProductVM> _productPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        //private const string CATEGORYNAME = "Keyboards";

        public ProductController(IProductPresentation<ProductVM> productPresentation, IWebHostEnvironment webHostEnvironment, ICategoryPresentation categoryPresentation)
        {
            _productPresentation = productPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductList(string categoryName, string searchbyModelName, int page = 1)
        {
            var actionName = "ProductList";
            var viewModels = _productPresentation.GetList(categoryName, searchbyModelName, actionName, page);

            return View(viewModels);
        }

       /* [HttpGet]
        public IActionResult SearchProductByModelName(string searchbyModelName)
        {
            var viewModel = _productPresentation.GetByModelName(searchbyModelName);
            var model = PagingList.Create(viewModel, 1, 1);
            return View(model);
        }*/

        [HttpGet]
        public IActionResult EditProductData(string modelName)
        {
            var keyboard = _productPresentation.GetByModelName(modelName);

            return View(keyboard);
        }

        public IActionResult ProductFullInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProductAsync(ProductVM model)
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

           _productPresentation.GetEditProductAsync(model);
            return RedirectToAction("ProductList");
        }

        public JsonResult RemoveProduct(string modelName)
        {
            return Json(_productPresentation.Remove(modelName));
        }
    }
}
