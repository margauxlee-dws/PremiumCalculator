using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Web.API.Models
{
    public class QuoteResponse
    {
        public decimal DeathPremium { get; set; }

        public QuoteResponse()
        {

        }

        public QuoteResponse(decimal deathPremium)
        {
            this.DeathPremium = deathPremium;
        }
    }
}
