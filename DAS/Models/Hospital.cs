using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int AreaId { get; set; }
        public virtual Area Area { get; set; }

        public int HospitalTypeId { get; set; }
        public virtual HospitalType HospitalType { get; set; }

        public string AdditionalAddress { get; set; }

        public ICollection<Chamber> Chamber { get; set; }


    }
}