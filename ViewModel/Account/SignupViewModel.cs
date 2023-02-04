using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Account
{
    public class SignupViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        
        [Required]
        [MinLength(6, ErrorMessage ="at least 6 characters")]
        public string? Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
