using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Persistence.Migrations
{
    public partial class AddDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "StatementDate",
                table: "Statements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDatetime",
                table: "Transactions",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "StatementDateTime",
                table: "Statements",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatementDateTime",
                table: "Statements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDatetime",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "StatementDate",
                table: "Statements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));


        }
    }
}
