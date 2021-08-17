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
    public class MonoblockPresentation : IMonoblockPresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public MonoblockPresentation(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditMonoblockAsync(MonoBlockVM model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.OperationalSystem} {model.Dimension} {model.MonoBlockInterface}" +
                    $" {model.WebCamera} {model.VideoCard} {model.Cpu} {model.Ram} {model.RamType} {model.Hdd}" +
                    $" {model.VideoMemorySize} {model.DisplayDiagonal} {model.DisplayResolution} {model.Weight} {model.Color}";
            }

            _productRepository.Save(product);
        }

    }
}
/*
 *  public string OperationalSystem { get; set; }
        public string Dimension { get; set; }
        public string MonoBlockInterface { get; set; } // HDMI
        public bool WebCamera { get; set; } // Yes
        public string VideoCard { get; set; } // 1650 GTX
        public string Cpu { get; set; }
        public int Ram { get; set; }
        public string RamType { get; set; } // DDR 4
        public string Hdd { get; set; } // 1Tb
        public int VideoMemorySize { get; set; }
 */