using E_WaveStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class OrderVM : BaseVM
    {        
        public decimal UnitPrice { get; set; } // Цена За Единицу
        public int Quantity { get; set; } // кол-во
        [Required]
        public DateTime DateAndTime { get; set; }
        public ApplicationUserVM ApplicationUser { get; set; }
        public ProductVM Product { get; set; }
        public PaymentTypeVM PaymentType { get; set; }
    }
}
