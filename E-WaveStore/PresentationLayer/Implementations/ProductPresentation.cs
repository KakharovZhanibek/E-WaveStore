using AutoMapper;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Interfaces;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class ProductPresentation<DbModel> : IProductPresentation<DbModel> where DbModel : ProductVM
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public const int PageSize = 5;

        public ProductPresentation(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public PagingList<ProductVM> GetList(string category, string searchbyModelName, string actionName, int page)
        {
            var models = _productRepository.GetAll().AsEnumerable().Select(x => _mapper.Map<ProductVM>(x));
            if (!String.IsNullOrEmpty(searchbyModelName))
            {
                models.Where(x => x.ModelName.Contains(searchbyModelName)).ToList();
                
            }
            else
            {
                models.Where(x => x.Category.CategoryName == category)              
               .OrderByDescending(x => x.BrandName)
               .ToList();
            }
               
            var products = PagingList.Create(models, PageSize, page);

            products.Action = actionName;
            return products;
        }

        public PagingList<DbModel> GetByBrandName(string modelName, string categoryName, string actionName, int page)
        {
            var models = _productRepository
               .GetAllByBrandName(modelName).Where(x => x.Category.CategoryName == categoryName)
               .Select(x => _mapper.Map<DbModel>(x))
               .OrderByDescending(x => x.ModelName)
               .ToList();
            var products = PagingList.Create(models, PageSize, page);

            products.Action = actionName;
            return products;

        }

        public DbModel GetByModelName(string modelName)
        {
            var model = _productRepository.GetByModelName(modelName);

            return _mapper.Map<DbModel>(model);
        }

        public DbModel GetById(long productId)
        {
            var model = _productRepository.Get(productId);

            return _mapper.Map<DbModel>(model);
        }

        

        public void GetEditProductAsync(DbModel model)
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
