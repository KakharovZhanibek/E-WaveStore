using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class PaymentTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
