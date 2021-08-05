using E_WaveStore.DataLayer.Entity;
using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Models.Entity
{
    public class Product : BaseModel
    {
        [MaxLength(100)]
        public string BrandName { get; set; }
        [MaxLength(100)]
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string ImgUrl { get; set; }
        public long SpecificationId { get; set; }
        public Category Category { get; set; }
       // public Specification Specification { get; set; }
        public string Specification { get; set; }
    }
}
