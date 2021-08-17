using E_WaveStore.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Interfaces
{
    public interface IKeyboardPresentation
    {
        void GetAddNewOrEditKeyboardAsync(KeyboardVM model);
    }
}
