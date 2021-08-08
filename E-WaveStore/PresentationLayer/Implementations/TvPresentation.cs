using AutoMapper;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class TvPresentation : ProductPresentation<TvVM>, ITvPresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public TvPresentation(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditTvAsync(TvVM model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.Smart} {model.Wifi} {model.Frequency} {model.Platform} " +
                    $"{model.DisplayDiagonal} {model.DisplayResolution} {model.Weight} {model.Color}";
            }

            _productRepository.Save(product);
        }
    }
}

/*
 * public bool Smart { get; set; }
        public bool Wifi { get; set; }

        public int Frequency { get; set; } // 100 Гц
        public string Platform { get; set; } // Android
 */