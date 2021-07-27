using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Entity
{
    public class Phone : CommonProperty
    {
        /*  public string BrandName { get; set; }
          public string ModelName { get; set; }*/
        public string SimType { get; set; }
        public int SimAmount { get; set; }
        public int CoreAmount { get; set; }
        public string OperatingSystem { get; set; }
        public int BuiltMemory { get; set; }
        public int Ram { get; set; }
        public int BatteryCapacity { get; set; } // единица измерения мАмпер       
        public string Cpu { get; set; }
        /*   public float DisplayDiagonal { get; set; }
           public string DisplayResolution { get; set; } // 2400*1800*/
        public string MainCamera { get; set; } // 64Mpx*8MPx*8Mpx
        public string FrontCamera { get; set; }
        public string NavSystem { get; set; }
        public bool Nfc { get; set; }
        public bool FaceRecognition { get; set; }
        public string BodyMaterial { get; set; } // Plastic
        public string UsbPort { get; set; } // Type C
        /*  public int Weight { get; set; } // единица измерения грамм
          public string Color { get; set; }*/
        /* public Category category { get; set; }*/
    }
}
