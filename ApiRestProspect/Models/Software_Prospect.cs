using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Software_Prospect
    {
        public int software_id { get; set; }
        public int prospect_id { get; set; }
        public int experience_level { get; set; }
        public int experience_time { get; set; }
    }
}
