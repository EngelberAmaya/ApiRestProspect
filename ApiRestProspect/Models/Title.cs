using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Title
    {
        public int title_id { get; set; }
        public string title_name { get; set; }
        public virtual Prospect Prospect { get; set; }

    }
}
