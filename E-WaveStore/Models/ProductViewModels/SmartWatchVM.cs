using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class SmartWatchVM : BaseVM
    {
        public string BraceletMaterial { get; set; }
        public string BodyMaterial { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        public string Sensor { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
