using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_Collections_CollectionId",
                table: "BankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_Payments_PaymentId",
                table: "BankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterDetails_Collections_CollectionId",
                table: "CashRegisterDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CashRegisterDetails_Payments_PaymentId",
                table: "CashRegisterDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Collections_CollectionId",
                table: "CustomerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Payments_PaymentId",
                table: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDetails_CollectionId",
                table: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDetails_PaymentId",
                table: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_CashRegisterDetails_CollectionId",
                table: "CashRegisterDetails");

            migrationBuilder.DropIndex(
                name: "IX_CashRegisterDetails_PaymentId",
                table: "CashRegisterDetails");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_CollectionId",
                table: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_PaymentId",
                table: "BankDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "PaymentNumber",
                table: "Payments",
                newName: "CollectionNumber");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CashRegisterId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BankId",
                table: "Payments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CashRegisterId",
                table: "Payments",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_BankId",
                table: "Collections",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CashRegisterId",
                table: "Collections",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CustomerId",
                table: "Collections",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Banks_BankId",
                table: "Collections",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CashRegisters_CashRegisterId",
                table: "Collections",
                column: "CashRegisterId",
                principalTable: "CashRegisters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Customers_CustomerId",
                table: "Collections",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Banks_BankId",
                table: "Payments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CashRegisters_CashRegisterId",
                table: "Payments",
                column: "CashRegisterId",
                principalTable: "CashRegisters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Banks_BankId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CashRegisters_CashRegisterId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Customers_CustomerId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Banks_BankId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CashRegisters_CashRegisterId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BankId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CashRegisterId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Collections_BankId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CashRegisterId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CustomerId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "CollectionNumber",
                table: "Payments",
                newName: "PaymentNumber");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CashRegisterId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CollectionId",
                table: "CustomerDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_PaymentId",
                table: "CustomerDetails",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisterDetails_CollectionId",
                table: "CashRegisterDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisterDetails_PaymentId",
                table: "CashRegisterDetails",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CollectionId",
                table: "BankDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_PaymentId",
                table: "BankDetails",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Collections_CollectionId",
                table: "BankDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Payments_PaymentId",
                table: "BankDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterDetails_Collections_CollectionId",
                table: "CashRegisterDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterDetails_Payments_PaymentId",
                table: "CashRegisterDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Collections_CollectionId",
                table: "CustomerDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Payments_PaymentId",
                table: "CustomerDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
