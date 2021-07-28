using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class Cart
    {
        public long Id { get; set; }        
        public string Username { get; set; }
        public int PaymentTypeID { get; set; }
        //public int ShippingMethodID { get; set; }
        //public string Note { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
