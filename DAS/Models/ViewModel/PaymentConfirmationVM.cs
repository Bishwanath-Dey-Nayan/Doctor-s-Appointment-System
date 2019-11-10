using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class PaymentConfirmationVM
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Personal Mobile No.")]
        public string PersonalMobileNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        public int Age { get; set; }


        public bool Pre_visited { get; set; }
        [Required]
        [Display(Name = "Bkash Mobile No.")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name ="Transaction Code")]
        public string Bkash_Tr_Code { get; set; }
    }
}