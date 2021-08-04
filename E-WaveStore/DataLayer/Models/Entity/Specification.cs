using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Models.Entity
{
    public class Specification : BaseModel
    {
        public float DisplayDiagonal { get; set; }
        [MaxLength(20)]
        public string DisplayResolution { get; set; } // 2400*1800
        public int Weight { get; set; } // единица измерения грамм
        [MaxLength(50)]
        public string Color { get; set; }
        public int KeysAmount { get; set; }
        [MaxLength(100)]
        public string ConnectionType { get; set; }
        [MaxLength(100)]
        public string Layout { get; set; }
        [MaxLength(100)]
        public string Dimension { get; set; }
        [MaxLength(100)]
        public string KeyType { get; set; } // mechanical
        [MaxLength(50)]
        public string BackLight { get; set; }
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
        public double PowerConsumption { get; set; }

        public int Frequency { get; set; }
        [MaxLength(50)]
        public string DeviceInterface { get; set; } // HDMI
        public bool? WebCamera { get; set; } // Yes
        [MaxLength(50)]
        public string VideoCard { get; set; } // 1650 GTX
        [MaxLength(20)]
        public string RamType { get; set; } // DDR 4
        public int VideoMemorySize { get; set; }
        [MaxLength(50)]
        public string Connection { get; set; } // проводной/беспроводной
        public int? ButtonAmount { get; set; }
        [MaxLength(50)]
        public string Type { get; set; } // sensory, laser, optical
        public int OpticalResolution { get; set; } // 4800 Dpi
        [MaxLength(20)]
        public string SimType { get; set; }
        public int SimAmount { get; set; }
        public int BuiltMemory { get; set; }
        public int BatteryCapacity { get; set; } // единица измерения мАмпер  
        [MaxLength(50)]
        public string MainCamera { get; set; } // 64Mpx*8MPx*8Mpx
        [MaxLength(50)]
        public string FrontCamera { get; set; }
        [MaxLength(50)]
        public string NavSystem { get; set; }
        public bool Nfc { get; set; }
        public bool FaceRecognition { get; set; }
        [MaxLength(50)]
        public string BodyMaterial { get; set; } // Plastic
        [MaxLength(30)]
        public string UsbPort { get; set; } // Type C
        [MaxLength(50)]
        public string BraceletMaterial { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        [MaxLength(50)]
        public string Sensor { get; set; }
        public bool Smart { get; set; }
        [MaxLength(50)]
        public string Platform { get; set; } // Android
    }
}
