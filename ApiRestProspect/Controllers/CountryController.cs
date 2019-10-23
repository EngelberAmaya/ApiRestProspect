using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Data;
using ApiRestProspect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestProspect.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly Context _context;
        public CountryController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await _context.Country.ToListAsync();
        }
    }
}