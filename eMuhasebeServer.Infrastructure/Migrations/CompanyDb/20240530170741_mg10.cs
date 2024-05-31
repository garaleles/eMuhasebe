using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class mg10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debt",
                table: "CashRegisters");

            migrationBuilder.DropColumn(
                name: "Receivable",
                table: "CashRegisters");

            migrationBuilder.RenameColumn(
                name: "Receivable",
                table: "CashRegisterDetails",
                newName: "WithdrawalAmount");

            migrationBuilder.RenameColumn(
                name: "Debt",
                table: "CashRegisterDetails",
                newName: "DepositAmount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CashRegisters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAmount",
                table: "CashRegisters",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DepositAmount",
                table: "CashRegisters",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WithdrawalAmount",
                table: "CashRegisters",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceAmount",
                table: "CashRegisters");

            migrationBuilder.DropColumn(
                name: "DepositAmount",
                table: "CashRegisters");

            migrationBuilder.DropColumn(
                name: "WithdrawalAmount",
                table: "CashRegisters");

            migrationBuilder.RenameColumn(
                name: "WithdrawalAmount",
                table: "CashRegisterDetails",
                newName: "Receivable");

            migrationBuilder.RenameColumn(
                name: "DepositAmount",
                table: "CashRegisterDetails",
                newName: "Debt");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CashRegisters",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "CashRegisters",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Receivable",
                table: "CashRegisters",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
