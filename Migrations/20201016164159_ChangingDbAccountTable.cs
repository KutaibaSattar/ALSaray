using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.SqlServer.Types;

namespace ALSaray.Migrations
{
    public partial class ChangingDbAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<HierarchyId>(
                name: "nodePath",
                table: "myDbAccts",
                nullable: true,
                oldClrType: typeof(SqlHierarchyId),
                oldType: "hierarchyid");

            migrationBuilder.CreateIndex(
                name: "IX_myDbAccts_acctKey",
                table: "myDbAccts",
                column: "acctKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_myDbAccts_acctKey",
                table: "myDbAccts");

            migrationBuilder.AlterColumn<SqlHierarchyId>(
                name: "nodePath",
                table: "myDbAccts",
                type: "hierarchyid",
                nullable: false,
                oldClrType: typeof(HierarchyId),
                oldNullable: true);
        }
    }
}
