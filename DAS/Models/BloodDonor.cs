using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class BloodDonor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }

        public int cityId { get; set; }
        public virtual City City { get; set; }

        public int  AreaId { get; set; }
        public virtual Area Area { get; set; }

        public string AdditionalAddress { get; set; }
        public bool isRequested { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime LastBloodDonateTime { get; set; }
}
}