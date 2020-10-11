using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumCalculator.Web.API.Data;
using PremiumCalculator.Web.API.Models;

namespace PremiumCalculator.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationsController : ControllerBase
    {
        private readonly PremiumCalculatorWebAPIContext _context;

        public OccupationsController(PremiumCalculatorWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Occupations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occupation>>> GetOccupation()
        {
            return await _context.Occupation.ToListAsync();
        }

        // GET: api/Occupations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Occupation>> GetOccupation(int id)
        {
            var occupation = await _context.Occupation.FindAsync(id);

            if (occupation == null)
            {
                return NotFound();
            }

            return occupation;
        }

    }
}
