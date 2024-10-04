using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class FoodTruckFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialDeal",
                table: "FoodTrucks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "FoodTrucks",
                newName: "Contact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FoodTrucks",
                newName: "SpecialDeal");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "FoodTrucks",
                newName: "LogoUrl");
        }
    }
}
