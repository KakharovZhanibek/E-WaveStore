using E_WaveStore.Models.ViewModels;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface IProductPresentation<DbModel> where DbModel : ProductVM
    {
        //PagingList<DbModel> GetList(string actionName, int page);
        PagingList<DbModel> GetList(string category, string searchbyModelName, string actionName, int page);
        PagingList<DbModel> GetByBrandName(string modelName, string categoryName, string actionName, int page);
        DbModel GetByModelName(string modelName);
        DbModel GetById(long productId);
        void GetEditProductAsync(DbModel model);
        bool Remove(string modelName);
    }
}
