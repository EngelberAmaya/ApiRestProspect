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


        public TitleController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Title>> GetTitle()
        {
            return await _context.Title.ToListAsync();
        }
    }
}
