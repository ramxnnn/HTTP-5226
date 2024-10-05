using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTruckUser_Users_FavoritedByUsersUserId",
                table: "FoodTruckUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTruckUser_User_FavoritedByUsersUserId",
                table: "FoodTruckUser",
                column: "FavoritedByUsersUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTruckUser_User_FavoritedByUsersUserId",
                table: "FoodTruckUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTruckUser_Users_FavoritedByUsersUserId",
                table: "FoodTruckUser",
                column: "FavoritedByUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
