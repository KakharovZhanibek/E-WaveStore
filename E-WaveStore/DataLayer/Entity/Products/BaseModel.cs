using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Entity
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        public string BrandName { get; set; }
        [MaxLength(100)]
        public string ModelName { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string ImgUrl { get; set; }
        public Category Category { get; set; }
    }
}
