using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS
{
    public class ConfirmedAppointment
    {
        [Key]
        public int ID { get; set; }

        public int AppointmentID { get; set; }
        public virtual Appointment Appointment { get; set; }

        public bool Confirmed { get; set; }
    }
}
