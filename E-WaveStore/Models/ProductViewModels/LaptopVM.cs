using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class LaptopVM : CommonPropertyVM
    {
        public string OperationalSystem { get; set; }
        public string Cpu { get; set; }
        public int Ram { get; set; }
        public int CoreAmount { get; set; }
        public string Hdd { get; set; } // not  
        public string Ssd { get; set; }
    }
}
