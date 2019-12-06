using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class PackType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Package> packages { get; set; }
    }
}