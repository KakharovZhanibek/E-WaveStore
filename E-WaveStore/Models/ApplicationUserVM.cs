using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class ApplicationUserVM
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]        
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
