using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "MenuItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
