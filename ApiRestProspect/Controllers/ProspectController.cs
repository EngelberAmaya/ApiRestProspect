using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Models;
using ApiRestProspect.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestProspect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectController : ControllerBase
    {
        private readonly Context _context;
        private readonly ProspectsRepository _repository;
        // GET: api/<controller>
        public ProspectController(Context context, ProspectsRepository repository)
        {
            _context = context;
            //this._repository = new ProspectsRepository(configuration);
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // return await _context.Prospect.ToListAsync();

            var response= await _repository.GetAll(null,30, 50,550,2000);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prospect>> Get(string id)
        {

            var prospect = await _context.Prospect.FindAsync(id);

            if (prospect == null)
            {
                return NotFound();
            }
            return prospect;
        }
        // POST api/<controller>
        [HttpPost("filter")]
        public async Task<ActionResult<Prospect>> Post2([FromBody] Filtro item)
        {
            //dynamic data = JsonConvert.DeserializeObject(item);
            var response = await _repository.GetAll((long)item.prospect_id, item.ageMin,item.ageMax , item.salaryMin, item.salaryMax);
            return Ok(response); //;
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Prospect>> Post([FromBody]Prospect item)
        {
            _context.Prospect.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.prospect_id }, item); 
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Prospect item)
        {
            if (id != item.prospect_id)
            {
                return NotFound();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prospect = await _context.Prospect.FindAsync(id);
            if (prospect == null)
            {
                return NotFound();
            }
            _context.Prospect.Remove(prospect);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
