using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Prospect
    {
        [Key]
        public int prospect_id { get; set; }
        public string prospect_name { get; set; }
        public string prospect_lastname { get; set; }
        public DateTime prospect_birthday { get; set; }
        [ForeignKey("City")]
        public int city_id { get; set; }
        public string prospect_address { get; set; }
        public string prospect_phonenumber { get; set; }
        public Byte prospect_cv { get; set; }
        public Byte prospect_photo { get; set; }
        public string prospect_link { get; set; }
        public int prospect_salary { get; set; }
        [ForeignKey("Title")]
        public int title_id { get; set; }



        public virtual Title Title { get; set; }
        public virtual City City { get; set; }
        public virtual Software_Prospect Software_Prospect { get; set; }

    }
}
