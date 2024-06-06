using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BrutTotal",
                table: "InvoiceDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DiscountRate",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountTotal",
                table: "InvoiceDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "InvoiceDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "InvoiceDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxRate",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxTotal",
                table: "InvoiceDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrutTotal",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "DiscountTotal",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TaxTotal",
                table: "InvoiceDetails");
        }
    }
}
