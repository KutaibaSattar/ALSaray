using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class RenamingPurchaseItemColumnToCAMEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "purchaseItems",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "purchaseItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "purchaseItems",
                newName: "price");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total",
                table: "purchaseItems",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "purchaseItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "purchaseItems",
                newName: "Price");

           
        }
    }
}
