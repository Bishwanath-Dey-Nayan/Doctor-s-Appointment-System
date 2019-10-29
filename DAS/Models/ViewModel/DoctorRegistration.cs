using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class DoctorRegistration
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Title/Designation")]
        public string Designation { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Mobile No")]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="BMDC Reg. No")]
        public string BMDCNo { get; set; }

        [Display(Name ="Description(Professional Statement)")]
        public string Description { get; set; }


        [Required]
        [Display(Name="Degree and other specification")]
        public string Degree_Spec { get; set; }

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