using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class KeyboardVM : BaseVM
    {
        public int KeysAmount { get; set; }
        public string ConnectionType { get; set; }
        public string Layout { get; set; }
        public string Dimension { get; set; }
        public string KeyType { get; set; } // mechanical
        public string Color { get; set; }
        public string BackLight { get; set; }
    }
}
