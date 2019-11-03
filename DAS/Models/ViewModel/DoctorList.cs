using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class DoctorList
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDesignation { get; set; }
        public string DoctorSpec { get; set; }
        public string HospitalName { get; set; }
        public string ChamberCity { get; set; }
        public string ChamberArea { get; set; }
        public double Fee { get; set; }

    }
}