using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Country
    {
        [Key]
        public string country_id { get; set; }
        public string country_name { get; set; }
        //relacion de uno a uno con City
        public virtual ICollection<City> City { get; set; }
        //public virtual City City { get; set; }
    }

}
