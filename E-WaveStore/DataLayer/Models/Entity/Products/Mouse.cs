using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Mouse : BaseModel
    {
        /* public string BrandName { get; set; }
         public string ModelName { get; set; }*/
        [MaxLength(50)]
        public string BackLight { get; set; }
        [MaxLength(50)]
        public string Connection { get; set; } // проводной/беспроводной
        public int? ButtonAmount { get; set; }
        [MaxLength(50)]
        public string Type { get; set; } // sensory, laser, optical
        public int OpticalResolution { get; set; } // 4800 Dpi
        public int? Weight { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        /*   public Category category { get; set; }*/
    }
}
