using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class ProductPresentation : IProductPresentation
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public const int PageSize = 5;

        public ProductPresentation(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }        

        public PagingList<ProductVM> GetList(string category, string actionName, int page)
        {
            var allModels = _productRepository.GetAll()
              .Select(x => _mapper.Map<ProductVM>(x))
              .Where(x => x.Category.CategoryName == category)
              .OrderByDescending(x => x.BrandName)
              .ToList();

            var products = PagingList.Create(allModels, PageSize, page);

            products.RouteValue = new RouteValueDictionary { { "categoryName", category } };

            //products.Action = actionName;
            products.Action = "ProductList";
            return products;
        }

        public PagingList<ProductVM> GetFilterProductbyPriceAndBrandName(string category, int minPrice, int maxPrice, string brandNames, string actionName, int page)
        {
            var allModels = _productRepository.GetAll().Select(x => _mapper.Map<ProductVM>(x));
            var selectedModels = new List<ProductVM>();
            var selectedModelsByBrandName = new List<ProductVM>();

            if (!String.IsNullOrEmpty(category))
            {
                selectedModels = allModels.Where(x => x.Category.CategoryName == category)
               .OrderByDescending(x => x.BrandName)
               .ToList();
            }
            else
            {
                selectedModels = allModels.ToList();
            }

            var selectedBypriceModels = maxPrice == 0 ? selectedModels.Where(x => x.Price > minPrice)
                                                      : selectedModels.Where(x => x.Price > minPrice).Where(x => x.Price < maxPrice);
            selectedBypriceModels.ToList();

            if (!String.IsNullOrEmpty(brandNames))
            {
                var brandNamesList = brandNames.Split(", ");//.ToList();
                
                foreach (var brandName in brandNamesList)
                {                    
                   var bn = brandName.Replace(", ", "").Replace(",", "");
                   
                    selectedModelsByBrandName.AddRange(selectedBypriceModels.Where(x => x.BrandName == bn));
                }

               // selectedModelsByBrandName.ToList();
            }

            var products = PagingList.Create(selectedModelsByBrandName, PageSize, page);
            products.RouteValue = new RouteValueDictionary { { "minPrice", minPrice }, { "maxPrice", maxPrice }, { "brandNames", brandNames } };
           
            products.Action = actionName;
            return products;
        }

        // https://localhost:5001/Product/ProductSearchModelName?categoryName=Laptops&searchbyModelName=x515MA
        public PagingList<ProductVM> GetProductSearchModelName(string searchbyModelName, string actionName, int page)
        {
            var selectedModels = _productRepository.GetAll().Select(x => _mapper.Map<ProductVM>(x))
                                                   .Where(x => x.ModelName.Contains(searchbyModelName)).ToList();

            var products = PagingList.Create(selectedModels, PageSize, page);
            products.RouteValue = new RouteValueDictionary { { "searchbyModelName", searchbyModelName } };

            products.Action = actionName;
            return products;
        }

        public PagingList<ProductVM> GetByBrandName(string modelName, string categoryName, string actionName, int page)
        {
            var models = _productRepository
               .GetAllByBrandName(modelName).Where(x => x.Category.CategoryName == categoryName)
               .Select(x => _mapper.Map<ProductVM>(x))
               .OrderByDescending(x => x.ModelName)
               .ToList();
            var products = PagingList.Create(models, PageSize, page);

            products.Action = actionName;
            return products;

        }

        public List<string> GetAllBrandNames(string categoryName)
        {
            return _productRepository.GetAll().Where(x => x.Category.CategoryName == categoryName).Select(x => x.BrandName).ToList();
        }

        public ProductVM GetByModelName(string modelName)
        {
            var model = _productRepository.GetByModelName(modelName);

            return _mapper.Map<ProductVM>(model);
        }

        public ProductVM GetById(long productId)
        {
            var model = _productRepository.Get(productId);

            return _mapper.Map<ProductVM>(model);
        }

        public void GetEditProductAsync(ProductVM model)
        {
            var product = _mapper.Map<Product>(model);

            _productRepository.Save(product);
        }

        public bool Remove(string modelName)
        {
            var model = _productRepository.GetByModelName(modelName);
            if (model == null)
            {
                return false;
            }

            _productRepository.Remove(model);

            return true;
        }

    }
}
