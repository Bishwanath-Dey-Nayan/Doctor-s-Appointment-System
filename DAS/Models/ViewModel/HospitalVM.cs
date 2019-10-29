using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class HospitalVM
    {
        [Required]
        [Display(Name ="Hospital Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name ="Area")]
        public int AreaId { get; set; }

        [Required]
        [Display(Name ="Hospital Type")]
        public int HospitalTypeId { get; set; }

        [Required]
        [Display(Name ="Exact Address")]
        public string AdditionalAddress { get; set; }
    }
}