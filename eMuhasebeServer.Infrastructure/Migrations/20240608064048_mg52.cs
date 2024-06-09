using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "CustomerDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "CustomerDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "CashRegisterDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "CashRegisterDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "BankDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "BankDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    CollectionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    PaymentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WithdrawalAmount = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Payments_PaymentId",
                table: "BankDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterDetails_Collections_CollectionId",
                table: "CashRegisterDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegisterDetails_Payments_PaymentId",
                table: "CashRegisterDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Collections_CollectionId",
                table: "CustomerDetails",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Payments_PaymentId",
                table: "CustomerDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Payments");

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
                name: "CollectionId",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CashRegisterDetails");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CashRegisterDetails");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "BankDetails");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "BankDetails");
        }
    }
}
