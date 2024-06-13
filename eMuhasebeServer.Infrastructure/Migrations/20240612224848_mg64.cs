using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceDetailId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "InvoiceDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId1",
                table: "InvoiceDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_InvoiceId",
                table: "ProductDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductDetailId",
                table: "ProductDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductDetailId1",
                table: "InvoiceDetails",
                column: "ProductDetailId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_ProductDetails_ProductDetailId1",
                table: "InvoiceDetails",
                column: "ProductDetailId1",
                principalTable: "ProductDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Invoices_InvoiceId",
                table: "ProductDetails",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_ProductDetails_ProductDetailId",
                table: "ProductDetails",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_ProductDetails_ProductDetailId1",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Invoices_InvoiceId",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_ProductDetails_ProductDetailId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_InvoiceId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ProductDetailId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ProductDetailId1",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ProductDetailId1",
                table: "InvoiceDetails");
        }
    }
}
