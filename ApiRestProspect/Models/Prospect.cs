using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Prospect
    {
        public int prospect_id { get; set; }
        public string prospect_name { get; set; }
        public string prospect_lastname { get; set; }
        public DateTime prospect_birthday { get; set; }
        public int city_id { get; set; }
        public string prospect_address { get; set; }
        public int prospect_phonenumber { get; set; }
        public object prospect_cv { get; set; }
        public object prospect_photo { get; set; }
        public object prospect_link { get; set; }
        public double prospect_salary { get; set; }
        public int title_id { get; set; }


    }
}
