using Microsoft.EntityFrameworkCore.Migrations;

namespace ALSaray.Migrations
{
    public partial class SeedingAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('All Accounts','All Accounts','/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Balance Sheet', 'Balance Sheet','/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Assets','Assets','/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Fixed Assets','Fixed Assets','/1/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Current Assets','Current Assets','/1/1/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Stores','Stores','/1/1/2/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Cashs','Cashs','/1/1/2/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Banks','Banks','/1/1/2/3/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Clients','Clients','/1/1/2/4/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Liabilities','Liabilities','/1/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Fixed Liabilities','Fixed Liabilities','/1/2/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Capital','Capital','/1/2/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Current Liabilities','Current Liabilities','/1/2/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Suppliers','Suppliers','/1/2/2/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Accumulated Profit','Accumulated Profit','/1/2/2/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Profit And Loss','Profit And Loss','/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Expenses','Expenses','/2/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Trading Expenses','Trading Expenses','/2/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Selling Cost','Selling Cost','/2/1/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Goods Sold','Goods Sold','/2/1/1/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Other Expenses','Other Expenses','/2/1/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Incomes','Incomes','/2/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Trading Incomes','Trading Incomes','/2/2/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Revenue','Revenue','/2/2/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Sales Revenue','Sales Revenue','/2/2/1/1/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Service revenue','Service revenue','/2/2/1/1/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Discount Given','Discount Given','/2/2/1/1/3/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Other Income','Other Income','/2/2/2/')");
            migrationBuilder.Sql("Insert Into myDbAccts (acctName,acctKey,nodepath) values ('Miscellaneous revenues','Miscellaneous revenues','/2/2/2/1/')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
