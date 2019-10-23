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


        [HttpGet("country/{country_id}")]
        public async Task<ActionResult> GetCityByCountry([FromRoute] string country_id)
        {
            var todoCityByCountry = await _context.City.Where(x => x.Country.country_id == country_id).ToListAsync();

            if (todoCityByCountry == null)
            {
                return NotFound();
            }

            return Ok(todoCityByCountry);
        }

    }
}
