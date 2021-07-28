using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class TvVM : CommonPropertyVM
    {
        public bool Smart { get; set; }
        public bool Wifi { get; set; }

        public int Frequency { get; set; } // 100 Гц
        public string Platform { get; set; } // Android
    }
}
