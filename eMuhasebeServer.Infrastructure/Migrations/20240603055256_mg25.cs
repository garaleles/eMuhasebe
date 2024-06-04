﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deposit",
                table: "Products",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Withdrawal",
                table: "Products",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Withdrawal",
                table: "Products");
        }
    }
}
