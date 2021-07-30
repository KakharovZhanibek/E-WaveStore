using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Keyboard : BaseModel
    {
        /*  public string BrandName { get; set; }
          public string ModelName { get; set; }*/
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
        public string Color { get; set; }
        [MaxLength(50)]
        public string BackLight { get; set; }
        /* public Category category { get; set; }*/
    }
}
