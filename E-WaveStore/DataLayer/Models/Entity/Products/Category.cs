using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Category : BaseModel
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
