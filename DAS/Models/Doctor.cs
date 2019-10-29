using DAS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }

        public int SpecialityId { get; set; }
        public virtual Speciality speciality { get; set; }

        public string Gender { get; set; }
        public string Image { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BMDCNo { get; set; }
        public string Description { get; set; }
        public string Degree_Spec { get; set; }

        public ICollection<Chamber> Chambers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<PaitentHistory> PaitentHistories { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
       
    }
}
