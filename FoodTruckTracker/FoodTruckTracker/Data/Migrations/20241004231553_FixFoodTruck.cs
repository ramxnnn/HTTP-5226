using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodTruck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodTruckLocation");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "FoodTrucks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodTrucks_LocationId",
                table: "FoodTrucks",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTrucks_Locations_LocationId",
                table: "FoodTrucks",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTrucks_Locations_LocationId",
                table: "FoodTrucks");

            migrationBuilder.DropIndex(
                name: "IX_FoodTrucks_LocationId",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "FoodTrucks");

            migrationBuilder.CreateTable(
                name: "FoodTruckLocation",
                columns: table => new
                {
                    FoodTrucksFoodTruckId = table.Column<int>(type: "int", nullable: false),
                    LocationsLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruckLocation", x => new { x.FoodTrucksFoodTruckId, x.LocationsLocationId });
                    table.ForeignKey(
                        name: "FK_FoodTruckLocation_FoodTrucks_FoodTrucksFoodTruckId",
                        column: x => x.FoodTrucksFoodTruckId,
                        principalTable: "FoodTrucks",
                        principalColumn: "FoodTruckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodTruckLocation_Locations_LocationsLocationId",
                        column: x => x.LocationsLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruckLocation_LocationsLocationId",
                table: "FoodTruckLocation",
                column: "LocationsLocationId");
        }
    }
}
