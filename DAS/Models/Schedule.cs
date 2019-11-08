using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAS
{
    public class Schedule
    {
        [Key]
        public int ID { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int ChamberID { get; set; }
        public virtual Chamber Chamber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double FirstAppointmentFee { get; set; }
        public string NextMeetingFee { get; set; }
        public int SlotNo { get; set; }

        public ICollection<Appointment> Appointments {get;set;}
    }
}
