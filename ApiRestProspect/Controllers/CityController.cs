using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Data;
using ApiRestProspect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestProspect.Controllers
{
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly Context _context;

        public CityController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetCity()
        {
            return await _context.City.ToListAsync();
        }


        /*
        [HttpGet("country/{country_id}")]
        public async Task<ActionResult> GetCountrybyCity([FromRoute] int country_id)
        {
            var cityCountry = await _context.City.Where(x => x.Country.country_id = country_id).ToListAsync();

            if (cityCountry == null)
            {
                return NotFound();
            }

            return Ok(cityCountry);
        }*/
    }
}
