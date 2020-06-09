using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresaMVC.Migrations
{
    public partial class ClientCpf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCpf",
                table: "Sale");

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "Sale",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Sale");

            migrationBuilder.AddColumn<string>(
                name: "ClientCpf",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
