using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public abstract class CommonProperty : BaseModel
    {
        public float DisplayDiagonal { get; set; }
        [MaxLength(20)]
        public string DisplayResolution { get; set; } // 2400*1800
        public int Weight { get; set; } // единица измерения грамм
        [MaxLength(50)]
        public string Color { get; set; }
    }
}
