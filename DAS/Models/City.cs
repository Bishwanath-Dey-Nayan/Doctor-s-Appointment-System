using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="CityName")]
        public string Name { get; set; }

        public ICollection<Area> Areas { get; set; }
        public ICollection<BloodDonor> BloodDonors { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
    }
}