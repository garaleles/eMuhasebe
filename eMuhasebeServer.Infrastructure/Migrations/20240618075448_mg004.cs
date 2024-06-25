using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "CheckNumber",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "Creditor",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "Debtor",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "Endorser",
                table: "CheckRegisterPayrolls");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CompanyCheckAccounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AverageMaturityDate",
                table: "CheckRegisterPayrolls",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CheckRegisterPayrollDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CompanyCheckAccounts",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AverageMaturityDate",
                table: "CheckRegisterPayrolls",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CheckRegisterPayrolls",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckNumber",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Creditor",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Debtor",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "CheckRegisterPayrolls",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endorser",
                table: "CheckRegisterPayrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CheckRegisterPayrollDetails",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
