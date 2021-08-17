using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Models.Entity
{
    public class Cart : BaseModel
    {
        public string ApplicationUserName { get; set; }
        public virtual Product Product { get; set; }
    }
}
