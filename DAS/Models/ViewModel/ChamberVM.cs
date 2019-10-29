using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class ChamberVM
    {
        public string Name { get; set; }
        [Required]
        [Display(Name ="Chamber Location")]
        public int HospitalID { get; set; }


    }
}