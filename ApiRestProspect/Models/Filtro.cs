using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Filtro
    { 
            public int? prospect_id { get; set; }
            public int? ageMin { get; set; }
            public int? ageMax { get; set; }
            public int? salaryMin { get; set; }
            public int? salaryMax { get; set; }
            /*public DateTime prospect_birthday { get; set; }
            public int? prospect_phonenumber { get; set; }
            public object prospect_cv { get; set; }
            public Byte? prospect_photo { get; set; }
            public Byte? prospect_link { get; set; }
            public int? prospect_salary { get; set; }
            public int? title_id { get; set; }
            public virtual Title Title { get; set; }
            public virtual City City { get; set; }
            //public virtual Software_Prospect Software_Prospect { get; set; }*/

        
    }
}
