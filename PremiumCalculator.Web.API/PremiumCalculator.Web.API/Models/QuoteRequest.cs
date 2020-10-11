using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Web.API.Models
{
    public class QuoteRequest
    {
        public QuoteRequest()
        {
        }

        public QuoteRequest(int occupationId, int deathSumInsured)
        {
            this.OccupationId = occupationId;
            this.DeathSumInsured = deathSumInsured;
        }

        public int OccupationId { get; set; }

        public int DeathSumInsured { get; set; }
    }
}
