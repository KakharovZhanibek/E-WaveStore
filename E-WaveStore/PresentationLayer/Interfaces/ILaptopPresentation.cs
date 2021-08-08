using E_WaveStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface ILaptopPresentation : IProductPresentation<LaptopVM>
    {
        void GetAddNewOrEditLaptopAsync(LaptopVM model);
    }
}
