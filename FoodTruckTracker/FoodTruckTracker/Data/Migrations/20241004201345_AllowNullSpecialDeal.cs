using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullSpecialDeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.AlterColumn<string>(
        name: "SpecialDeal",
        table: "FoodTrucks",
        nullable: true, // Allow null values
        oldClrType: typeof(string),
        oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
       migrationBuilder.AlterColumn<string>(
       name: "SpecialDeal",
       table: "FoodTrucks",
       nullable: false, // Revert back to not allowing nulls
       oldClrType: typeof(string),
       oldNullable: true);
        }
    }
}
