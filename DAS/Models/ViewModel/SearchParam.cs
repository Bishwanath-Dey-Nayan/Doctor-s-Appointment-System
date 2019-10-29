using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Models.ViewModel
{
    public class SearchParam
    {
        public int CityId { get; set; }
        public int SpecialityId { get; set; }
        public string SearchType { get; set; }
    }

}