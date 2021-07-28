using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(50)]
        public string OperationalSystem { get; set; }
        [MaxLength(50)]
        public string Dimension { get; set; }
        [MaxLength(50)]
        public string MonoBlockInterface { get; set; } // HDMI
        public bool? WebCamera { get; set; } // Yes
        [MaxLength(50)]
        public string VideoCard { get; set; } // 1650 GTX
        [MaxLength(50)]
        public string Cpu { get; set; }
        public int Ram { get; set; }
        [MaxLength(20)]
        public string RamType { get; set; } // DDR 4
        [MaxLength(30)]
        public string Hdd { get; set; } // 1Tb
        public int VideoMemorySize { get; set; }

        /*  public int Weight { get; set; }*/
        /*  public Category category { get; set; }*/
    }
}

