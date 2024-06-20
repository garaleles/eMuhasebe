using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "CheckRegisterPayrollDetailId",
                table: "Checks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckRegisterPayrollDetailId",
                table: "Checks",
                column: "CheckRegisterPayrollDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckDetails_CheckRegisterPayrollDetailId",
                table: "CheckDetails",
                column: "CheckRegisterPayrollDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckDetails_CheckRegisterPayrollDetails_CheckRegisterPayrollDetailId",
                table: "CheckDetails",
                column: "CheckRegisterPayrollDetailId",
                principalTable: "CheckRegisterPayrollDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_CheckRegisterPayrollDetails_CheckRegisterPayrollDetailId",
                table: "Checks",
                column: "CheckRegisterPayrollDetailId",
                principalTable: "CheckRegisterPayrollDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckDetails_CheckRegisterPayrollDetails_CheckRegisterPayrollDetailId",
                table: "CheckDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_CheckRegisterPayrollDetails_CheckRegisterPayrollDetailId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckRegisterPayrollDetailId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_CheckDetails_CheckRegisterPayrollDetailId",
                table: "CheckDetails");

            migrationBuilder.DropColumn(
                name: "CheckRegisterPayrollDetailId",
                table: "Checks");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckDetails_Checks_CheckId",
                table: "CheckDetails",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
