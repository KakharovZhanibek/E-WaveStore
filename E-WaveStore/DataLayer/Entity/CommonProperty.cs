using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class CommonProperty : BaseModel
    {
        public float DisplayDiagonal { get; set; }
        public string DisplayResolution { get; set; } // 2400*1800
        public int Weight { get; set; } // единица измерения грамм
        public string Color { get; set; }
    }
}
