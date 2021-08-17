using E_WaveStore.Models;
using E_WaveStore.Models.ViewModels;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface ICartPresentation
    {
        public void AddCart(string applicationUserName, ProductVM productVM);
        public bool RemoveProductFromCart(long cartId);
        public PagingList<CartVM> GetAllProductInCart(string applicationUsername);
    }
}
