﻿using AutoMapper;
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
    public class SmartWatchPresentation : ISmartWatchPresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public SmartWatchPresentation(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditSmartWatchAsync(SmartWatchVM model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.BraceletMaterial} {model.BodyMaterial} {model.Wifi}  " +
                    $"{model.Bluetooth} {model.Sensor} {model.Weight} {model.Color}";
            }

            _productRepository.Save(product);
        }
    }
}
