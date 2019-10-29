using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class Login
    {
        [Display(Name ="E-mail Address")]
        [Required(ErrorMessage ="Field can`t be empty")]
        [EmailAddress(ErrorMessage ="The Email Address is not valid.")]
        public string Email { get; set; }

        
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}