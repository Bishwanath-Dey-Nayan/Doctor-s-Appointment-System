using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class HospitalType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Hospital Type Name")]
        public string Name { get; set; }

        public ICollection<Hospital> Hospitals { get; set; }
    }
}