using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS
{
    public class Chamber
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int HospitalID { get; set; }
        public virtual  DAS.Models.Hospital Hospital { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        public string DoctorName { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<PaitentHistory> PaitentHistories { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
