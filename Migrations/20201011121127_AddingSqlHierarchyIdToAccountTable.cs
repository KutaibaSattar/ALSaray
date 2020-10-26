using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.SqlServer.Types;

namespace ALSaray.Migrations
{
    public partial class AddingSqlHierarchyIdToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<SqlHierarchyId>(
                name: "nodePath",
                table: "myDbAccts",
                nullable: true/*,
                defaultValue: Microsoft.SqlServer.Types.SqlHierarchyId.Parse(new System.Data.SqlTypes.SqlString("NULL"))*/);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nodePath",
                table: "myDbAccts");
        }
    }
}
