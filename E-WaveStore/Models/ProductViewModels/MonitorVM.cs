using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class MonitorVM : CommonPropertyVM
    {
        public string MonitorcInterface { get; set; } // HDMI
        public double PowerConsumption { get; set; }
        public string Dimension { get; set; } // 557*493*206
        public int Frequency { get; set; }
    }
}
