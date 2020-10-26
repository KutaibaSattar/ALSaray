using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class AddingKeyColumnToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "acctKey",
                table: "myDbAccts",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "acctKey",
                table: "myDbAccts");
        }
    }
}
