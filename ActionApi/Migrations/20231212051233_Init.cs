using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActionApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mainCategories",
                columns: table => new
                {
                    ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    export = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    margin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainCategories", x => x.ids);
                });

            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    warranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceNet = table.Column<double>(type: "float", nullable: false),
                    vat = table.Column<int>(type: "int", nullable: false),
                    pkwiu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    available = table.Column<int>(type: "int", nullable: false),
                    EAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturerPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sizeWidth = table.Column<int>(type: "int", nullable: false),
                    sizeHeight = table.Column<int>(type: "int", nullable: false),
                    sizeLength = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    urlImg1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImg2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImg3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImg4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImg5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    export = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    margin = table.Column<int>(type: "int", nullable: false),
                    idMainCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mainCategories");

            migrationBuilder.DropTable(
                name: "producers");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "subCategories");
        }
    }
}
