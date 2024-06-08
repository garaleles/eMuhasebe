using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg46 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseDetailId",
                table: "ExpenseDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseDetailId",
                table: "CashRegisterDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseDetailId",
                table: "BankDetails",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseDetailId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "ExpenseDetailId",
                table: "CashRegisterDetails");

            migrationBuilder.DropColumn(
                name: "ExpenseDetailId",
                table: "BankDetails");
        }
    }
}
