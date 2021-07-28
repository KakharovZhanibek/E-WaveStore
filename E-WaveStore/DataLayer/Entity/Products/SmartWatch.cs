using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class SmartWatch : BaseModel
    {
        /* public string BrandName { get; set; }
         public string ModelName { get; set; }*/
        [MaxLength(50)]
        public string BraceletMaterial { get; set; }
        [MaxLength(50)]
        public string BodyMaterial { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        [MaxLength(50)]
        public string Sensor { get; set; }
        public int Weight { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }

        /*public Category category { get; set; }*/
    }
}
