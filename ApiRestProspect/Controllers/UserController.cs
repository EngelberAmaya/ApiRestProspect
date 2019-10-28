using ApiRestProspect.Data;
using ApiRestProspect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiRestProspect.Controllers
{
    

    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserRepository _repository;
       

        public UserController(Context context, UserRepository repository)
        {
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        
        // con procedimiento almaceado
        
        [HttpGet("name/{user_name}/{user_password}")]
        public async Task<IActionResult> GetLogin([FromRoute] string user_name, [FromRoute]  string user_password)
        {
            //myList = null;
            //String[] arr = Array.Empty<string>();
            // String[] arr = new String[0];
            string[] arr = new string[] { };
            // string[] arr = null;
            //string[] a = { };
            //var arr = Array.Empty<string>();
            

            var response = await _repository.GetLogin(user_name, user_password);
            
            if (response == null || response == null) 
            {
                //return NotFound();
                return null;
            }
            else {
                return Ok(response);
            }
                     
            
        }

    }
}
   