using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Models.Entity
{
    public class PaymentType : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
