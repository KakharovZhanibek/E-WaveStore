using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
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
        public string Specification { get; set; }
        public virtual Category Category { get; set; }
    }
}
