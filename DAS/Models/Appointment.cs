using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        public string P_Name { get; set; }
        public string Age { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool Prev_visit { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int ChamberID { get; set; }
        public virtual Chamber Chamber { get; set; }

        public int SechduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public ICollection<ConfirmedAppointment> ConfirmedAppointments { get; set; }
    }
}
