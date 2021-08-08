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
    public class PhonePresentation : ProductPresentation<PhoneVm>, IPhonePresentation
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public PhonePresentation(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void GetAddNewOrEditPhoneAsync(PhoneVm model)
        {
            var product = _mapper.Map<Product>(model);

            if (!(model.Id > 0))
            {

                product.Specification = $"{model.SimType} {model.SimAmount} {model.CoreAmount} {model.OperatingSystem} {model.BuiltMemory} " +
                    $"{model.BatteryCapacity} {model.Cpu} {model.Ram} {model.MainCamera} {model.FrontCamera} {model.NavSystem} " +
                    $"{model.Nfc} {model.FaceRecognition} {model.BodyMaterial} {model.UsbPort} {model.DisplayDiagonal} {model.DisplayResolution} " +
                    $" {model.Weight} {model.Color}";
            }

            _productRepository.Save(product);
        }
    }
}
/*
 public string SimType { get; set; }
        public int SimAmount { get; set; }
        public int CoreAmount { get; set; }
        public string OperatingSystem { get; set; }
        public int BuiltMemory { get; set; }
        public int Ram { get; set; }
        public int BatteryCapacity { get; set; } // единица измерения мАмпер  
        public string Cpu { get; set; }
        public string MainCamera { get; set; } // 64Mpx*8MPx*8Mpx
        public string FrontCamera { get; set; }
        public string NavSystem { get; set; }
        public bool Nfc { get; set; }
        public bool FaceRecognition { get; set; }
        public string BodyMaterial { get; set; } // Plastic
        public string UsbPort { get; set; } // Type C
 */