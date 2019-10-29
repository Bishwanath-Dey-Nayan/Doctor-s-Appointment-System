using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class BloodDonorRegistration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Mobile No.")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="E-Mail Address")]
        public string Email { get; set; }


        public string Gender { get; set; }

        [Required]
        [Display(Name ="Blood Group")]
        public int BloodGroupId { get; set; }

        [Required]
        [Display(Name ="City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name ="Area")]
        public int AreaId { get; set; }

        [Display(Name ="Additional Address")]
        public string AdditionalAddress { get; set; }

        [Display(Name ="Last Blood Donation Date")]
        [DataType(DataType.Date)]
        public DateTime LastBloodDonateTime { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}