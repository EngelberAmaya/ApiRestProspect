using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string role_name { get; set; }
    }
}
