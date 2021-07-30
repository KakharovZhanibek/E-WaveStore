using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Laptop : CommonProperty
    {
        /* public string BrandName { get; set; }
         public string ModelName { get; set; }*/
        /*  public string ScreenResolution { get; set; }
          public int ScreenDiagonal { get; set; }*/
        [MaxLength(100)]
        public string OperationalSystem { get; set; }
        [MaxLength(100)]
        public string Cpu { get; set; }
        public int Ram { get; set; }
        public int CoreAmount { get; set; }
        [MaxLength(50)]
        public string Hdd { get; set; } // not      
        [MaxLength(50)]
        public string Ssd { get; set; }

        /* public string Color { get; set; }
         public int Weight { get; set; }*/

        /*   public Category category { get; set; }*/
    }
}
