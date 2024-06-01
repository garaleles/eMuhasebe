﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankDetailId",
                table: "BankDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BankDetailId",
                table: "BankDetails",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
