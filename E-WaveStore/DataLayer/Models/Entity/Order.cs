using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Models.Entity
{
    public class Order : BaseModel
    {
        public decimal UnitPrice { get; set; } // Цена За Единицу
        public int Quantity { get; set; } // кол-во
        [Required]
        public DateTime DateAndTime { get; set; }
        public virtual User ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
