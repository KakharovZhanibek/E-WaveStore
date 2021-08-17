using E_WaveStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class CartVM : BaseVM
    {
        public string ApplicationUserName { get; set; }
        public ProductVM Product { get; set; }
    }
}
