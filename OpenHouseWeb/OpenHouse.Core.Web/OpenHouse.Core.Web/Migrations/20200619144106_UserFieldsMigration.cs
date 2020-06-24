using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenHouse.Core.Web.Migrations
{
    public partial class UserFieldsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telephone",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "telephone",
                table: "AspNetUsers");
        }
    }
}
