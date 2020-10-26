using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class requiredAccountIdofPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_myDbAccts_accId",
                table: "purchases");

            migrationBuilder.AlterColumn<int>(
                name: "accId",
                table: "purchases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_myDbAccts_accId",
                table: "purchases",
                column: "accId",
                principalTable: "myDbAccts",
                principalColumn: "acctId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_myDbAccts_accId",
                table: "purchases");

            migrationBuilder.AlterColumn<int>(
                name: "accId",
                table: "purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_myDbAccts_accId",
                table: "purchases",
                column: "accId",
                principalTable: "myDbAccts",
                principalColumn: "acctId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
