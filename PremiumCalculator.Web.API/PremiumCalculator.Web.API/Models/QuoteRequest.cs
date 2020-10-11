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

        public QuoteRequest(int occupationId, int deathSumInsured, int age)
        {
            this.OccupationId = occupationId;
            this.DeathSumInsured = deathSumInsured;
            this.Age = age;
        }

        public int OccupationId { get; set; }

        public int DeathSumInsured { get; set; }

        public int Age { get; set; }
    }
}
