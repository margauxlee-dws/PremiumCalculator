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
    public class RatingController : ControllerBase
    {
        private readonly PremiumCalculatorWebAPIContext _context;

        public RatingController(PremiumCalculatorWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rating/CalculateDeathPremium
        [Route("CalculateDeathPremium")]
        [HttpPost]
        public async Task<ActionResult<QuoteResponse>> CalculateDeathPremium(QuoteRequest req)
        {
 
            var query = await (
                            from o in _context.Set<Occupation>().Where(o => o.Id == req.OccupationId)
                            join orf in _context.Set<OccupationRatingFactor>()
                                on o.OccupationTypeId equals orf.OccupationTypeId
                            select new { orf.Factor }
                        ).ToListAsync();

            if (query.FirstOrDefault() != null)
            {
                return new QuoteResponse((req.DeathSumInsured * query.FirstOrDefault().Factor * req.Age)/1000 * 12);
            }
            else
            {
                return NotFound();
            }

        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}
