using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class AddingColumnsToPurchaseItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "gtotal",
                table: "purchases",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

           

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "purchaseItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

          
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "purchaseItems",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "purchaseItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "purchaseItems");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "purchaseItems");

            migrationBuilder.AlterColumn<float>(
                name: "gtotal",
                table: "purchases",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

         

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "purchaseItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

           
        }
    }
}
