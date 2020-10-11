using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumCalculator.Web.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    OccupationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationRatingFactor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationTypeId = table.Column<int>(nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(3, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationRatingFactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Occupation",
                columns: new[] { "Id", "Name", "OccupationTypeId" },
                values: new object[,]
                {
                    { 1, "Cleaner", 3 },
                    { 2, "Doctor", 1 },
                    { 3, "Author", 2 },
                    { 4, "Farmer", 4 },
                    { 5, "Mechanic", 4 },
                    { 6, "Forist", 3 }
                });

            migrationBuilder.InsertData(
                table: "OccupationRatingFactor",
                columns: new[] { "Id", "Factor", "OccupationTypeId" },
                values: new object[,]
                {
                    { 1, 1.0m, 1 },
                    { 2, 1.25m, 2 },
                    { 3, 1.50m, 3 },
                    { 4, 1.75m, 4 }
                });

            migrationBuilder.InsertData(
                table: "OccupationType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Professional" },
                    { 2, "White Collar" },
                    { 3, "Light Manual" },
                    { 4, "Heavy Manual" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "OccupationRatingFactor");

            migrationBuilder.DropTable(
                name: "OccupationType");
        }
    }
}
