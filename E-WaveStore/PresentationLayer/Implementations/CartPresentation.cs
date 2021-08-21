using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Interfaces;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class CartPresentation : ICartPresentation
    {
        private ICartRepository _cartRepository;        
        private IMapper _mapper;

        public const int PageSize = 5;

        public CartPresentation(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;            
            _mapper = mapper;            
        }
        public void AddCart(string applicationUserName, ProductVM productVM)
        {
            var cartVM = new CartVM
            {
                ApplicationUserName = applicationUserName,
                Product = productVM
            };

            //cartVM.Product.Id = 0;

            var cart = _mapper.Map<Cart>(cartVM);
            _cartRepository.Save(cart);
        }

        public bool RemoveProductFromCart(long cartId)
        {
            var cart = _cartRepository.Get(cartId);
           
            if (cart == null)
            {
                return false;
            }

            _cartRepository.Remove(cart);

            return true;
        }

        public PagingList<CartVM> GetAllProductInCart(string applicationUsername)
        {          

            var products = _cartRepository.GetAll().Select(x => _mapper.Map<CartVM>(x))
                                                    .Where(x => x.ApplicationUserName == applicationUsername).ToList();

            var allProductsInCart = PagingList.Create(products, PageSize, 1);
          
            return allProductsInCart;
        }
    }
}
