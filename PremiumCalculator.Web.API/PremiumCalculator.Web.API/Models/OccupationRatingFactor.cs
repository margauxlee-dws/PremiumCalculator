using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Web.API.Models
{
    public class OccupationRatingFactor
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("OccupationType")]
        public int OccupationTypeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Factor { get; set; }

    }
}
