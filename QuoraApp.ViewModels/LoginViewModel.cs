using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }
    }
}
