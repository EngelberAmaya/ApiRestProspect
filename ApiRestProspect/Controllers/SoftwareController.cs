using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Data;
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
        private readonly SoftwareRepository _softRep;

        public SoftwareController(Context context, SoftwareRepository softRep)
        {
            _context = context;
            _softRep = softRep;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Software>> GetSoftware()
        {
            return await _context.Software.ToListAsync();
        }

        
        [HttpGet("{software_id}")]
        public async Task<ActionResult<Software>> GetAllSoftware(int software_id)
        {
            var todoSoftware = await _context.Software.FindAsync(software_id);

            if (todoSoftware == null)
            {
                return NotFound();
            }

            return todoSoftware;
        }

        [HttpGet("prospect/{prospect_id}")]
        public async Task<ActionResult> GetTodoItem2([FromRoute] int prospect_id)
        {
            var todoSoftware = await _context.Software.Where(x=>x.Software_Prospect.prospect_id==prospect_id).ToListAsync();

            if (todoSoftware == null)
            {
                return NotFound();
            }

            return Ok(todoSoftware);
        }

        
        [HttpPost]
        public async Task PostSoftware([FromBody] Software software)
        {
            await _softRep.InsertSoftware(software);
        }

   
        [HttpPut("{software_id}")]
        public async Task<IActionResult> PutSoftware(int software_id, [FromBody] Software software)
        {

            //await _basRep.UpdateUser(user, id);
            await _softRep.UpdateSoftware(software_id, software);

            return Ok();
        }


        [HttpDelete("{software_id}")]
        public async Task<IActionResult> DeleteSoftware(int software_id)
        {
            var Item = await _context.Software.FindAsync(software_id);

            if (Item == null)
            {
                return NotFound();
            }

            _context.Software.Remove(Item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
