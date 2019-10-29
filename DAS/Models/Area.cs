using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class Area
    {
        [Key]
        public int ID { get; set;}

        [Required]
        [Display(Name ="City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [Required]
        [Display(Name ="Area")]
        public string Name { get; set; }

        public ICollection<BloodDonor> BloodDonors { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
    }
}