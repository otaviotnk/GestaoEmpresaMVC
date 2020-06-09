using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresaMVC.Migrations
{
    public partial class SaleQuant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Sale");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Sale",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Sale");

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
