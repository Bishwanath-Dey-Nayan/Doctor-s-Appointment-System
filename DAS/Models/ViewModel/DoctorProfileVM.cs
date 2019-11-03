using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class DoctorProfileVM
    {
        public DoctorList DoctorList { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}