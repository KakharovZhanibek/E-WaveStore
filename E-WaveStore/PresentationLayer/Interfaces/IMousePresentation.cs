using E_WaveStore.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface IMousePresentation : IProductPresentation<MouseVM>
    {
        void GetAddNewOrEditMouseAsync(MouseVM model);
    }
}
