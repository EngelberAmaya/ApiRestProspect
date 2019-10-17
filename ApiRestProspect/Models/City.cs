using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class City
    {
        public int city_id { get; set; }
        public string country_name { get; set; }
        public int country_id { get; set; }
    }
}
