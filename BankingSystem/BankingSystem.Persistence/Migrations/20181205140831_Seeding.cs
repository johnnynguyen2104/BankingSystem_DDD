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
                values: new object[] { 1, "4111111111111111", "THB", true });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "Currency", "IsActive" },
                values: new object[] { 2, "4222222222222222", "THB", true });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "Currency", "IsActive" },
                values: new object[] { 3, "4333333333333333", "THB", true });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { 1, 1, 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { 2, 2, 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "AccountId", "ClosingBalance", "StatementDetails" },
                values: new object[] { 3, 3, 0m, "This statement on Dec, 2018" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { 1, 1, "Deposit", 100m, "This is the initial deposit." });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { 2, 2, "Deposit", 200m, "This is the initial deposit." });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Action", "Amount", "Note" },
                values: new object[] { 3, 3, "Deposit", 300m, "This is the initial deposit." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
