using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumCalculator.Web.API.Models;

namespace PremiumCalculator.Web.API.Data
{
    public class PremiumCalculatorWebAPIContext : DbContext
    {
        public PremiumCalculatorWebAPIContext(DbContextOptions<PremiumCalculatorWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PremiumCalculator.Web.API.Models.OccupationType> OccupationType { get; set; }

        public DbSet<PremiumCalculator.Web.API.Models.Occupation> Occupation { get; set; }

        public DbSet<PremiumCalculator.Web.API.Models.OccupationRatingFactor> OccupationRatingFactor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OccupationType>().HasData(
                new OccupationType { Id = 1, Name = "Professional" },
                new OccupationType { Id = 2, Name = "White Collar" },
                new OccupationType { Id = 3, Name = "Light Manual" },
                new OccupationType { Id = 4, Name = "Heavy Manual" }
            );

            modelBuilder.Entity<Occupation>().HasData(
               new Occupation { Id = 1, Name = "Cleaner", OccupationTypeId = 3 },
               new Occupation { Id = 2, Name = "Doctor", OccupationTypeId = 1 },
               new Occupation { Id = 3, Name = "Author", OccupationTypeId = 2 },
               new Occupation { Id = 4, Name = "Farmer", OccupationTypeId = 4 },
               new Occupation { Id = 5, Name = "Mechanic", OccupationTypeId = 4 },
               new Occupation { Id = 6, Name = "Forist", OccupationTypeId = 3 }
           );

            modelBuilder.Entity<OccupationRatingFactor>().HasData(
               new OccupationRatingFactor { Id = 1, OccupationTypeId = 1, Factor = 1.0m },
               new OccupationRatingFactor { Id = 2, OccupationTypeId = 2, Factor = 1.25m },
               new OccupationRatingFactor { Id = 3, OccupationTypeId = 3, Factor = 1.50m },
               new OccupationRatingFactor { Id = 4, OccupationTypeId = 4, Factor = 1.75m }
           );
        }

    }

}