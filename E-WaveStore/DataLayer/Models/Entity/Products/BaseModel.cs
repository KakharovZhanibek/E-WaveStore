using E_WaveStore.DataLayer.Entity;
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
    }
}
