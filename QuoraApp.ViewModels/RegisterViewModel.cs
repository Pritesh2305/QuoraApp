using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string  Password { get; set; }

        [Required]
        [Compare("Password")]
        public string  ConfirmPassword { get; set; }

        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
