using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Software
    {
        [Key]
        public int software_id { get; set; }
        public string software_name { get; set; }
        public virtual Software_Prospect Software_Prospect { get; set; }
    }
}
