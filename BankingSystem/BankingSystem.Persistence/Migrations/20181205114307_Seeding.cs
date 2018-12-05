using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Persistence.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "Currency", "IsActive" },
                values: new object[] { new Guid("29ecb256-899e-4684-b3df-638766a60fa1"), "4111111111111111", "THB", true });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "Currency", "IsActive" },
                values: new object[] { new Guid("deeec4fc-a1d0-49a4-9187-3e65ad5db4aa"), "4222222222222222", "USD", true });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "Currency", "IsActive" },
                values: new object[] { new Guid("c6538a28-9164-4634-a39c-d57433f261f0"), "4333333333333333", "EUR", true });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { new Guid("9d957e32-d3d1-4554-8543-78ccfb432988"), new Guid("29ecb256-899e-4684-b3df-638766a60fa1"), 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { new Guid("f497976c-b913-42c6-8a56-15c6e08cc940"), new Guid("deeec4fc-a1d0-49a4-9187-3e65ad5db4aa"), 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { new Guid("5ae8336b-2060-4d78-832a-ab0176f5303a"), new Guid("c6538a28-9164-4634-a39c-d57433f261f0"), 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { new Guid("025a133a-60ac-47e5-879d-509b40d25010"), new Guid("29ecb256-899e-4684-b3df-638766a60fa1"), "Deposit", 100m, "This is the initial deposit." });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { new Guid("2dcaeba6-d4ba-4234-8768-e32323328597"), new Guid("deeec4fc-a1d0-49a4-9187-3e65ad5db4aa"), "Deposit", 200m, "This is the initial deposit." });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { new Guid("620ef155-4e10-4fd7-a3ca-4da76cd74150"), new Guid("c6538a28-9164-4634-a39c-d57433f261f0"), "Deposit", 300m, "This is the initial deposit." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: new Guid("5ae8336b-2060-4d78-832a-ab0176f5303a"));

            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: new Guid("9d957e32-d3d1-4554-8543-78ccfb432988"));

            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: new Guid("f497976c-b913-42c6-8a56-15c6e08cc940"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("025a133a-60ac-47e5-879d-509b40d25010"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("2dcaeba6-d4ba-4234-8768-e32323328597"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("620ef155-4e10-4fd7-a3ca-4da76cd74150"));

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: new Guid("29ecb256-899e-4684-b3df-638766a60fa1"));

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: new Guid("c6538a28-9164-4634-a39c-d57433f261f0"));

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: new Guid("deeec4fc-a1d0-49a4-9187-3e65ad5db4aa"));
        }
    }
}
