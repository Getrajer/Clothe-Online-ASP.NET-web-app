using Microsoft.EntityFrameworkCore.Migrations;

namespace ClotheOnline.Migrations
{
    public partial class IntitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    xsQuantity = table.Column<int>(nullable: false),
                    sQuantity = table.Column<int>(nullable: false),
                    mQuantity = table.Column<int>(nullable: false),
                    lQuantity = table.Column<int>(nullable: false),
                    xlQuantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOfProduction = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    PhotoPath2 = table.Column<string>(nullable: true),
                    PhotoPath3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
