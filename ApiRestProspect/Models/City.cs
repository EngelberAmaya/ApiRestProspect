using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class City
    {
        public int city_id { get; set; }
        public string country_name { get; set; }

        //relacion de uno a uno con Country
        [ForeignKey("Country")]
        public int country_id { get; set; }
        
        public virtual Country Country { get; set; }
    }
}
