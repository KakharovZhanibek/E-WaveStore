using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class PaymentType : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
