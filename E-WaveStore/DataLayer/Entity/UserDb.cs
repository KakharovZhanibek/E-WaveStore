using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Entity
{
    public class UserDb
    {
        [Key]       
        public long Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required]
        public string Password { get; set; }
    }
}
