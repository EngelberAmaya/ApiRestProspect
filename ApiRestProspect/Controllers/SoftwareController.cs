using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestProspect.Controllers
{
    [Route("[controller]")]
    public class SoftwareController : ControllerBase
    {
        private readonly Context _context;

        public SoftwareController(Context context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Software>> GetSoftware()
        {
            return await _context.Software.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
