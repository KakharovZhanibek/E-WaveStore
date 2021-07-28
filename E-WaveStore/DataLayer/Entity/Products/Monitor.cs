using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Monitor : CommonProperty
    {
        /*   public string BrandName { get; set; }
           public string ModelName { get; set; }*/
        /* public string ScreenResolution { get; set; }
         public int ScreenDiagonal{ get; set; }*/
        [MaxLength(50)]
        public string MonitorcInterface { get; set; } // HDMI
        public double PowerConsumption { get; set; }
        [MaxLength(50)]
        public string Dimension { get; set; } // 557*493*206
        public int Frequency { get; set; }

        /*  public int Weight { get; set; }*/

        /* public Category category { get; set; }*/
    }
}
