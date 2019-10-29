using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS
{
     public class PaitentHistory
    {
        [Key]
        public int ID { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int ChamberID { get; set; }
        public virtual Chamber Chamber { get; set; }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string ProblemSpec { get; set; }
        public string Description { get; set; }
        public DateTime MettingDate { get; set; }
        public DateTime NextMeet { get; set; }
        public string PrescribedMed { get; set; }

    }
}
