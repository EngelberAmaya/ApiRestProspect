using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Software_Prospect
    {
        [Key]
        [ForeignKey("Software")]
        public int software_id { get; set; }

        [ForeignKey("Prospect")]
        public int prospect_id { get; set; }
        public int experience_level { get; set; }
        public int experience_time { get; set; }

        public virtual Prospect Prospect { get; set; }
        public virtual Software Software { get; set; }
    }
}
