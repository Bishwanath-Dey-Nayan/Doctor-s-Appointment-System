using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Doctor> Doctors { get; set; }
    }
}