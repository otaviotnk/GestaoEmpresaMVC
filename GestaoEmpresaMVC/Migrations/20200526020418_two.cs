using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresaMVC.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "ProductCategory",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     CategoryName = table.Column<string>(nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ProductCategory", x => x.Id);
                 });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
