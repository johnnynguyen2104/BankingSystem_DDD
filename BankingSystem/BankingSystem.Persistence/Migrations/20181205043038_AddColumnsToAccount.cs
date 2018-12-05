using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Persistence.Migrations
{
    public partial class AddColumnsToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "BankAccounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BankAccounts",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityDate",
                table: "BankAccounts",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "LastActivityDate",
                table: "BankAccounts");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "BankAccounts",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
