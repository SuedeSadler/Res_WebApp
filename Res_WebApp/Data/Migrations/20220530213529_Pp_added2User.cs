using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Res_WebApp.Data.Migrations
{
    public partial class Pp_added2User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TablePic",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TablePic",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
