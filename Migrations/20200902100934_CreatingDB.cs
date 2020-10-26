using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class CreatingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    catId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.catId);
                });

            migrationBuilder.CreateTable(
                name: "myDbAccts",
                columns: table => new
                {
                    acctId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    acctName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myDbAccts", x => x.acctId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    prodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodName = table.Column<string>(maxLength: 255, nullable: false),
                    catId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.prodId);
                    table.ForeignKey(
                        name: "FK_products_categories_catId",
                        column: x => x.catId,
                        principalTable: "categories",
                        principalColumn: "catId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    purchId = table.Column<long>(type: "bigint", nullable: false),
                    purchNo = table.Column<string>(maxLength: 255, nullable: false),
                    pMethod = table.Column<string>(maxLength: 255, nullable: true),
                    gtotal = table.Column<float>(nullable: false),
                    accId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.purchId);
                    table.ForeignKey(
                        name: "FK_purchases_myDbAccts_accId",
                        column: x => x.accId,
                        principalTable: "myDbAccts",
                        principalColumn: "acctId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseItems",
                columns: table => new
                {
                    purchItemId = table.Column<long>(type: "bigint", nullable: false),
                    prodId = table.Column<int>(nullable: true),
                    purchId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseItems", x => x.purchItemId);
                    table.ForeignKey(
                        name: "FK_purchaseItems_products_prodId",
                        column: x => x.prodId,
                        principalTable: "products",
                        principalColumn: "prodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseItems_purchases_purchId",
                        column: x => x.purchId,
                        principalTable: "purchases",
                        principalColumn: "purchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_catId",
                table: "products",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseItems_prodId",
                table: "purchaseItems",
                column: "prodId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseItems_purchId",
                table: "purchaseItems",
                column: "purchId");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_accId",
                table: "purchases",
                column: "accId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseItems");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "myDbAccts");
        }
    }
}
