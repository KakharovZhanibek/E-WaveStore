using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Entity
{
    public class Phone : CommonProperty
    {
        /*  public string BrandName { get; set; }
          public string ModelName { get; set; }*/
        [MaxLength(20)]
        public string SimType { get; set; }
        public int SimAmount { get; set; }
        public int CoreAmount { get; set; }
        [MaxLength(50)]
        public string OperatingSystem { get; set; }
        public int BuiltMemory { get; set; }
        public int Ram { get; set; }
        public int BatteryCapacity { get; set; } // единица измерения мАмпер  
        [MaxLength(50)]
        public string Cpu { get; set; }
        /*   public float DisplayDiagonal { get; set; }
           public string DisplayResolution { get; set; } // 2400*1800*/
        [MaxLength(50)]
        public string MainCamera { get; set; } // 64Mpx*8MPx*8Mpx
        [MaxLength(50)]
        public string FrontCamera { get; set; }
        [MaxLength(50)]
        public string NavSystem { get; set; }
        public bool Nfc { get; set; }
        public bool FaceRecognition { get; set; }
        [MaxLength(50)]
        public string BodyMaterial { get; set; } // Plastic
        [MaxLength(30)]
        public string UsbPort { get; set; } // Type C
        /*  public int Weight { get; set; } // единица измерения грамм
          public string Color { get; set; }*/
        /* public Category category { get; set; }*/
    }
}
