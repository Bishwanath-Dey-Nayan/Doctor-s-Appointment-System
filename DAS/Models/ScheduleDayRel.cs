using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class ScheduleDayRel
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string DayName { get; set; }
    }
}