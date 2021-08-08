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
    public class MonitorPresentation : ProductPresentation<MonitorVM>, IMonitorPresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public MonitorPresentation(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditMonitorAsync(MonitorVM model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.MonitorcInterface} {model.PowerConsumption} {model.Dimension} {model.Frequency} {model.DisplayDiagonal}{model.DisplayResolution} {model.Color}";
            }

            _productRepository.Save(product);
        }
    }
}/* public string MonitorcInterface { get; set; } // HDMI
        public double PowerConsumption { get; set; }
        public string Dimension { get; set; } // 557*493*206
        public int Frequency { get; set; }*/
