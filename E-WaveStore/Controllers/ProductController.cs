using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_WaveStore.Models;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;

namespace E_WaveStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductPresentation _productPresentation;
        private IOrderPresentation _orderPresentation;
        private ICategoryPresentation _categoryPresentation;
        private IWebHostEnvironment _webHostEnvironment;
        private ICartPresentation _cartPresentation;        
        private readonly ILogger _logger;
        public ProductController(IProductPresentation productPresentation, IWebHostEnvironment webHostEnvironment,
            ICategoryPresentation categoryPresentation, ICartPresentation cartPresentation,
            IOrderPresentation orderPresentation, ILogger<ProductController> logger)
        {

            _productPresentation = productPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
            _cartPresentation = cartPresentation;
            _orderPresentation = orderPresentation;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Test Log Message");
            return View();
        }

        [HttpGet]
        //[ResponseCache(CacheProfileName = "Caching")]
        public IActionResult ProductList(string categoryName, int page = 1)
        {
            var actionName = "ProductList";
            var viewModels = _productPresentation.GetList(categoryName, actionName, page);

            ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
            ViewBag.CategoryName = categoryName;

            try
            {
                ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
                _logger.LogInformation("success");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                _logger.LogInformation("error {err}", ex);
            }

            return View(viewModels);
        }

        // https://localhost:5001/Product/FilterProductbyPriceAndBrandName?categoryName=Laptops&minPrice=0&maxPrice=0&brandNames=Prestigio,%20Acer
        [HttpGet]
        public IActionResult FilterProductbyPriceAndBrandName(string categoryName, int minPrice, int maxPrice, string brandNames, int page = 1)
        {
            //var actionName = "FilterProductbyPriceAndBrandName";
            var actionName = "ProductList";

            var viewModels = _productPresentation.GetFilterProductbyPriceAndBrandName(categoryName, minPrice, maxPrice, brandNames, actionName, page);

            ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
            ViewBag.CategoryName = categoryName;

            return View("ProductList", viewModels);            
        }

        [HttpGet]
        public IActionResult ProductSearchModelName(string searchbyModelName, string categoryName, int page = 1)
        {
            var actionName = "ProductList";
            var viewModels = _productPresentation.GetProductSearchModelName(searchbyModelName, actionName, page);
            ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
            ViewBag.CategoryName = categoryName;
            ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);

            return View("ProductList", viewModels);
        }


        [HttpGet]
        [Authorize(Roles ="admin, manager")]
        public IActionResult EditProductData(string modelName)
        {
            var keyboard = _productPresentation.GetByModelName(modelName);

            return View(keyboard);
        }

        [HttpGet]
        public IActionResult ProductFullInfo(string modelName)
        {
            var product = _productPresentation.GetByModelName(modelName);
            var specificationAsStrList = product.Specification.Split(", ");
            ViewBag.SpecificationAsStrList = specificationAsStrList;
            ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
            return View(product);

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

        [Authorize(Roles = "admin")]
        public JsonResult RemoveProduct(string modelName)
        {
            return Json(true);
            //return Json(_productPresentation.Remove(modelName));
        }

        [Authorize(Roles = "user")]
        public IActionResult AddProductToCart(string modelName)
        {
            var productVM = _productPresentation.GetByModelName(modelName);

            _cartPresentation.AddCart(User.Identity.Name, productVM);

            ViewBag.BrandNames = _productPresentation.GetAllBrandNames(productVM.Category.CategoryName);

            return View("ProductList");
        }

        [Authorize(Roles = "user")]
        public IActionResult AllProductInCart()
        {
            var allProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
            return View(allProductsInCart);
        }

        [Authorize(Roles = "user")]
        public IActionResult RemoveProductFromCart(string modelName)
        {
            var allProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
            var productInCart = allProductsInCart.FirstOrDefault(x => x.Product.ModelName == modelName);
            _cartPresentation.RemoveProductFromCart(productInCart.Id);
            return View("AllProductInCart");
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Order(string modelName)
        {
            var product = _productPresentation.GetByModelName(modelName);
            ViewBag.Product = product;
            ViewBag.PaymentTypeNames = _orderPresentation.GetAllPaymentTypeNames();
            return View();
        }
        [HttpPost]
        public IActionResult Order(OrderVM orderVM)
        {
            /* 1) проверить есть в БД юзер с определенным email
             2) если нет добавить new User { }; userManager.CreateAsync(User, "User");
             3) вожможно создам модельку с AccountNumber / CVV / PhoneNumber
             4) потом проверить подходят ли введенные AccountNumber / CVV / PhoneNumber с данными в БД
             5) если нет вернуть на view с сообщением о неправильности данных
             6) Дату назначить dateTime.Now
             7) получить полноценную модель OrderVM
             8) сохранить в БД*/
            return View();
        }

    }
}
