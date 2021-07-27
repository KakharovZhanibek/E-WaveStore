using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class SmartWatch : BaseModel
    {
        /* public string BrandName { get; set; }
         public string ModelName { get; set; }*/
        public string BraceletMaterial { get; set; }
        public string BodyMaterial { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        public float Diagonal { get; set; } //1,77 дюйм
        public string Sensor { get; set; }
        public string Dimension { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        /*public Category category { get; set; }*/
    }
}
