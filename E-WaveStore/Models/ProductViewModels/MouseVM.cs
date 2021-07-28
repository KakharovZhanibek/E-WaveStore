using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class MouseVM : BaseVM
    {
        public string BackLight { get; set; }
        public string Connection { get; set; } // проводной/беспроводной
        public int ButtonAmount { get; set; }
        public string Type { get; set; } // sensory, laser, optical
        public int OpticalResolution { get; set; } // 4800 Dpi
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
