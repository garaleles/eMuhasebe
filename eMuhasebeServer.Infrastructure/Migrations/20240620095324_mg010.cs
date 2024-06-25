using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CheckRegisterPayrollId",
                table: "Checks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CheckId",
                table: "CheckRegisterPayrolls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckRegisterPayrollId",
                table: "Checks",
                column: "CheckRegisterPayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckRegisterPayrolls_CheckId",
                table: "CheckRegisterPayrolls",
                column: "CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRegisterPayrolls_Checks_CheckId",
                table: "CheckRegisterPayrolls",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_CheckRegisterPayrolls_CheckRegisterPayrollId",
                table: "Checks",
                column: "CheckRegisterPayrollId",
                principalTable: "CheckRegisterPayrolls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckRegisterPayrolls_Checks_CheckId",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_CheckRegisterPayrolls_CheckRegisterPayrollId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckRegisterPayrollId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_CheckRegisterPayrolls_CheckId",
                table: "CheckRegisterPayrolls");

            migrationBuilder.DropColumn(
                name: "CheckRegisterPayrollId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "CheckRegisterPayrolls");
        }
    }
}
