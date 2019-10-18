using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Models
{
    public class User
    {
        [Key]
        public string user_name { get; set; }
        public string user_password { get; set; }
        public int role_id { get; set; }
       
    }
}
