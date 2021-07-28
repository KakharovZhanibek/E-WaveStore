using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Entity
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
