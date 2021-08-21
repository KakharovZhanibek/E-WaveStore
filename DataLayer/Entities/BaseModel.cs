using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
