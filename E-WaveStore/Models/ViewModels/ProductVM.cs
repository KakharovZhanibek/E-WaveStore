using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models.ViewModels
{
    public class ProductVM
    {
        public long Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile ImgFile { get; set; }       
        public CategoryVM Category { get; set; }
        public string Specification { get; set; }
    }
}
