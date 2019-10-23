using ApiRestProspect.Data;
using ApiRestProspect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Controllers
{
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly Context _context;
        private readonly TitleRepository _titRep;

        public TitleController(Context context, TitleRepository titRep)
        {
            _context = context;
            _titRep = titRep;
        }

        [HttpGet]
        public async Task<IEnumerable<Title>> GetTitle()
        {
            return await _context.Title.ToListAsync();
        }



        [HttpGet("{title_id}")]
        public async Task<ActionResult<Title>> GetAllSoftware(int title_id)
        {
            var todoTitle = await _context.Title.FindAsync(title_id);

            if (todoTitle == null)
            {
                return NotFound();
            }

            return todoTitle;
        }


        [HttpPost]
        public async Task PostTitle([FromBody] Title title)
        {
            await _titRep.InsertTitle(title);
        }

        [HttpPut("{title_id}")]
        public async Task<IActionResult> PutTitle(int title_id, [FromBody] Title title)
        {
            await _titRep.UpdateTitle(title_id, title);

            return Ok();
        }


        [HttpDelete("{title_id}")]
        public async Task DeleteTitle(int title_id)
        {
            //await _repository.DeleteById(id);
            await _titRep.DeleteTitle(title_id);
        }
    }
}
