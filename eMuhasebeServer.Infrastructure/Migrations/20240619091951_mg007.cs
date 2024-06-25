using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails");

            migrationBuilder.DropIndex(
                name: "IX_CheckDetails_CheckId",
                table: "CheckDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "CheckDetailId",
                table: "Checks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks",
                column: "CheckDetailId",
                unique: true,
                filter: "[CheckDetailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_CheckDetails_CheckDetailId",
                table: "Checks",
                column: "CheckDetailId",
                principalTable: "CheckDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_CheckDetails_CheckDetailId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "CheckDetailId",
                table: "Checks");

            migrationBuilder.CreateIndex(
                name: "IX_CheckDetails_CheckId",
                table: "CheckDetails",
                column: "CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
