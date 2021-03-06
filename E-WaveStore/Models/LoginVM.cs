using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.Models
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        /*  [Required]
          [Display(Name = "Email")]
          public string Email { get; set; }*/

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
