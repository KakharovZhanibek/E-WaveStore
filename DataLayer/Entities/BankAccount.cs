using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class BankAccount : BaseModel
    {
        [MaxLength(16)]
        public string AccountNumber { get; set; }
        public int AccountCvv { get; set; }
        [MaxLength(5)]
        public string AccountDate { get; set; }
    }
}
