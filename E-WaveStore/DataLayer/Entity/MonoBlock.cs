using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class MonoBlock : CommonProperty
    {/*
        public string BrandName { get; set; }
        public string ModelName { get; set; }*/
        /*  public string ScreenResolution { get; set; }
          public int ScreenDiagonal{ get; set; }*/
        public string OperationalSystem { get; set; }
        public string Dimension { get; set; }
        public string MonoBlockInterface { get; set; } // HDMI
        public bool WebCamera { get; set; } // Yes
        public string VideoCard { get; set; } // 1650 GTX
        public string Cpu { get; set; }
        public int Ram { get; set; }
        public string RamType { get; set; } // DDR 4
        public string Hdd { get; set; } // 1Tb
        public int VideoMemorySize { get; set; }

        /*  public int Weight { get; set; }*/
        /*  public Category category { get; set; }*/
    }
}

