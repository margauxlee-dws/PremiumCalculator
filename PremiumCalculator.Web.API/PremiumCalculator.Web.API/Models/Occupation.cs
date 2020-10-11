using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Web.API.Models
{
    public class Occupation
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        [Required]
        [ForeignKey("OccupationType")]
        public int OccupationTypeId { get; set; }

    }
}
