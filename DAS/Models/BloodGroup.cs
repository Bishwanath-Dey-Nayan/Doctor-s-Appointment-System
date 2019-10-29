using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class BloodGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Blood Group")]
        public string Name { get; set; }

        public ICollection<BloodDonor> BloodDonors { get; set; }
    }
}