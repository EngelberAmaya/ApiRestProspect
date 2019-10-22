using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class City
    {
        [Key]
        public int city_id { get; set; }
        public string city_name { get; set; }

        //relacion de uno a uno con Country
        [ForeignKey("Country")]
        public string country_id { get; set; }
        
        public Country Country { get; set; }
    }
}
