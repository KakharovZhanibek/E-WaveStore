using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IBankAccountPresentation _bankAccountPresentation;
        private readonly ILogger _logger;
        public ProductController(IProductPresentation productPresentation, IWebHostEnvironment webHostEnvironment,
            ICategoryPresentation categoryPresentation, ICartPresentation cartPresentation,
            IOrderPresentation orderPresentation, ILogger<ProductController> logger, IBankAccountPresentation bankAccountPresentation)
        {

            _productPresentation = productPresentation;
            _webHostEnvironment = webHostEnvironment;
            _categoryPresentation = categoryPresentation;
            _cartPresentation = cartPresentation;
            _orderPresentation = orderPresentation;
            _logger = logger;
            _bankAccountPresentation = bankAccountPresentation;
        }


        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult ProductList(string categoryName, int page = 1)
        {
            var actionName = "ProductList";

            try
            {
                var viewModels = _productPresentation.GetList(categoryName, actionName, page);

                ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
                ViewBag.CategoryName = categoryName;

                ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
                _logger.LogInformation("Requested data was got successfully.");
                return View(viewModels);
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex, "Error has been occured in ProductList method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        
        [HttpGet]
        public IActionResult FilterProductbyPriceAndBrandName(string categoryName, int minPrice, int maxPrice, string brandNames, int page = 1)
        {            
            var actionName = "ProductList";
            try
            {
                var viewModels = _productPresentation.GetFilterProductbyPriceAndBrandName(categoryName, minPrice, maxPrice, brandNames, actionName, page);

                ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
                ViewBag.CategoryName = categoryName;

                return View("ProductList", viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in FilterProductbyPriceAndBrandName method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult ProductSearchModelName(string searchbyModelName, string categoryName, int page = 1)
        {
            var actionName = "ProductList";
            try
            {
                var viewModels = _productPresentation.GetProductSearchModelName(searchbyModelName, actionName, page);
                ViewBag.BrandNames = _productPresentation.GetAllBrandNames(categoryName);
                ViewBag.CategoryName = categoryName;
                ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);

                return View("ProductList", viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in ProductSearchModelName method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult ProductFullInfo(string modelName)
        {
            try
            {
                var product = _productPresentation.GetByModelName(modelName);
                var specificationAsStrList = product.Specification.Split(", ");
                ViewBag.SpecificationAsStrList = specificationAsStrList;
                var specificationsDictionary = new Dictionary<string, string>();

                for (int i = 0; i < specificationAsStrList.Length; i++)
                {
                    var temp = specificationAsStrList[i].Split(":");
                    specificationsDictionary.Add(temp[0], temp[1]);
                }

                ViewBag.SpecificationsDictionary = specificationsDictionary;

                ViewBag.ProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in EditProductData get method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
        public IActionResult EditProductData(string modelName)
        {
            try
            {
                var product = _productPresentation.GetByModelName(modelName);
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in EditProductData get method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }       

        [HttpPost]
        public async Task<IActionResult> AddNewOrEditProduct(ProductVM model)
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

            try
            {
                _productPresentation.GetAddNewOrEditProduct(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in EditProductAsync post method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            ViewBag.BrandNames = _productPresentation.GetAllBrandNames(model.Category.CategoryName);
            ViewBag.CategoryName = model.Category.CategoryName;
            return RedirectToAction("ProductList", "Product", new { categoryName = model.Category.CategoryName });
        }

        [Authorize(Roles = "admin")]
        public JsonResult RemoveProduct(string modelName)
        {
            return Json(_productPresentation.Remove(modelName));
        }

        [Authorize(Roles = "user")]
        public IActionResult AddProductToCart(string modelName)
        {
            try
            {
                var productVM = _productPresentation.GetByModelName(modelName);

                _cartPresentation.AddCart(User.Identity.Name, productVM);

                ViewBag.BrandNames = _productPresentation.GetAllBrandNames(productVM.Category.CategoryName);

                return View("ProductList");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in AddProductToCart method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "user")]
        public IActionResult AllProductInCart()
        {
            try
            {
                var allProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
                return View(allProductsInCart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in AllProductInCart method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "user")]
        public IActionResult RemoveProductFromCart(string modelName)
        {
            try
            {
                var allProductsInCart = _cartPresentation.GetAllProductInCart(User.Identity.Name);
                var productInCart = allProductsInCart.FirstOrDefault(x => x.Product.ModelName == modelName);
                _cartPresentation.RemoveProductFromCart(productInCart.Id);
                return View("AllProductInCart");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in RemoveProductFromCart method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Order(string modelName)
        {
            try
            {
                var product = _productPresentation.GetByModelName(modelName);
                ViewBag.Product = product;
                ViewBag.PaymentTypeNames = _orderPresentation.GetAllPaymentTypeNames();

                var order = new OrderVM();
                order.UnitPrice = product.Price;              
                order.Product = product;
                order.Quantity = 1;

                return View(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has been occured in Order method.");
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }
        [HttpPost]
        public IActionResult Order(OrderVM orderVM, string accountNumber, string accountDate, int accountCvv)
        {
            var product = _productPresentation.GetByModelName(orderVM.Product.ModelName);
            orderVM.Product = product;
            orderVM.DateAndTime = DateTime.Now;

            if (!String.IsNullOrEmpty(accountNumber) && !String.IsNullOrEmpty(accountDate) && accountCvv != 0)
            {
                bool flag = false;
                var bankAccount = new BankAccountVM
                {
                    AccountNumber = accountNumber.Replace(" ", ""),
                    AccountCvv = accountCvv,
                    AccountDate = accountDate
                };
                flag = _bankAccountPresentation.GetBankAccountVM(bankAccount);

                if (!flag)
                {
                   return RedirectToAction("Order", "Product", new { modelName = product.ModelName });
                }
            }

            _orderPresentation.AddOrder(orderVM);
            return RedirectToAction("ProductList", "Product", new { categoryName = product.Category.CategoryName });
        }

    }
}
