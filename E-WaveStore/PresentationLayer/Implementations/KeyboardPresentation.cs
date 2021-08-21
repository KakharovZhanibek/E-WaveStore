using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class KeyboardPresentation : IKeyboardPresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public KeyboardPresentation(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditKeyboardAsync(KeyboardVM model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.KeysAmount} {model.BackLight}";
            }

            _productRepository.Save(product);
        }

    }
}
