using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresaMVC.Migrations
{
    public partial class ProductsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeProductId",
                table: "Product",
                column: "TypeProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
