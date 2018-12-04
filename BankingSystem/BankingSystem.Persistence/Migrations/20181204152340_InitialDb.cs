using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Persistence.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 30, nullable: true),
                    CurrentBalance = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Currency = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    StatementDate = table.Column<DateTime>(nullable: false),
                    StatementDetails = table.Column<string>(maxLength: 50, nullable: true),
                    ClosingBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_BankAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Action = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    TransactionDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AccountId",
                table: "Statements",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
