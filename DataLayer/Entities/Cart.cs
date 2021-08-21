using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Cart : BaseModel
    {
        public string ApplicationUserName { get; set; }
        public virtual Product Product { get; set; }
    }
}
