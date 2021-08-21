using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Category : BaseModel
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
