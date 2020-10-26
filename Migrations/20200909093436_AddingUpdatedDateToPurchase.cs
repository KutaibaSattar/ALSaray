using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class AddingUpdatedDateToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "purchases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "purchases");
        }
    }
}
