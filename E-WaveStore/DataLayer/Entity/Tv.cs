using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Tv : CommonProperty
    {
        /*public string BrandName { get; set; }
        public string ModelName { get; set; }*/
        /* public string ScreenResolution { get; set; }
         public int ScreenDiagonal { get; set; }*/
        public bool Smart { get; set; }
        public bool Wifi { get; set; }

        public int Frequency { get; set; } // 100 Гц
        public string Platform { get; set; } // Android
        /* public string Color { get; set; }
         public int Weight { get; set; }*/
        /*public Category category { get; set; }*/
    }
}
