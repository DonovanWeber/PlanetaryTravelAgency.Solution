using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetaryTravelAgency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Weather = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Radiation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.PlanetId);
                });

            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    SpaceshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.SpaceshipId);
                });

            migrationBuilder.CreateTable(
                name: "PlanetSpaceship",
                columns: table => new
                {
                    PlanetSpaceshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpaceshipId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetSpaceship", x => x.PlanetSpaceshipId);
                    table.ForeignKey(
                        name: "FK_PlanetSpaceship_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetSpaceship_Spaceships_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "Spaceships",
                        principalColumn: "SpaceshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanetSpaceship_PlanetId",
                table: "PlanetSpaceship",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetSpaceship_SpaceshipId",
                table: "PlanetSpaceship",
                column: "SpaceshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanetSpaceship");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Spaceships");
        }
    }
}
