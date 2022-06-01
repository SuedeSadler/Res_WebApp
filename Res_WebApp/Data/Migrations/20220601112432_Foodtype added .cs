using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Res_WebApp.Data.Migrations
{
    public partial class Foodtypeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Menu");
        }
    }
}
