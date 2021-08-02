using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public abstract class CommonPropertyVM : BaseVM
    {
        public float DisplayDiagonal { get; set; }
        public string DisplayResolution { get; set; } // 2400*1800
        public int Weight { get; set; } // единица измерения грамм
        public string Color { get; set; }
    }
}
