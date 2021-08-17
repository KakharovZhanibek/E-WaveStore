using E_WaveStore.Models.ViewModels;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface IProductPresentation
    {
        //PagingList<DbModel> GetList(string actionName, int page);
        // PagingList<ProductVM> GetList(decimal minPrice, decimal maxPrice, string category, string searchbyModelName, string actionName, int page);
        //PagingList<ProductVM> GetList(int minPrice, int maxPrice, string category, string searchbyModelName, string actionName, int page);
        PagingList<ProductVM> GetList(string category, string actionName, int page);
        PagingList<ProductVM> GetFilterProductbyPriceAndBrandName(string category, int minPrice, int maxPrice, string brandNames, string actionName, int page);
        PagingList<ProductVM> GetProductSearchModelName(string searchbyModelName, string actionName, int page);
        PagingList<ProductVM> GetByBrandName(string modelName, string categoryName, string actionName, int page);
        List<string> GetAllBrandNames(string categoryName);
        ProductVM GetByModelName(string modelName);
        ProductVM GetById(long productId);
        void GetEditProductAsync(ProductVM model);
        bool Remove(string modelName);
    }
}
