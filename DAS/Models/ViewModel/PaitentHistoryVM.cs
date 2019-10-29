using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class PaitentHistoryVM
    {
        [Required]
        [Display(Name ="Paitent Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="paitent Age")]
        public string Age { get; set; }

        public string Address { get; set; }

        [Required]
        [Display(Name ="Chamber")]
        public int ChamberId { get; set; }

        [Required]
        [Display(Name ="Problem Statement")]
        public string ProblemSpec { get; set; }

        [Display(Name ="Problem Details")]
        public string Description { get; set; }

        [Display(Name ="Next Meeting Date")]
        [DataType(DataType.Date)]
        public DateTime NextMeet { get; set; }
    }
}