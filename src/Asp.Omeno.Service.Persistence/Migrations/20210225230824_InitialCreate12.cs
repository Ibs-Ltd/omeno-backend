using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Omeno.Service.Persistence.Migrations
{
    public partial class InitialCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxPrice",
                table: "AutoBids",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "AutoBids");
        }
    }
}
