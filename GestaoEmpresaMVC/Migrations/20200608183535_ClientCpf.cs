using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresaMVC.Migrations
{
    public partial class ClientCpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientCpf",
                table: "Sale",
                nullable: true);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         

            migrationBuilder.DropColumn(
                name: "ClientCpf",
                table: "Sale");
        }
    }
}
