using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks");

            migrationBuilder.AlterColumn<Guid>(
                name: "CheckDetailId",
                table: "Checks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks",
                column: "CheckDetailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks");

            migrationBuilder.AlterColumn<Guid>(
                name: "CheckDetailId",
                table: "Checks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckDetailId",
                table: "Checks",
                column: "CheckDetailId",
                unique: true,
                filter: "[CheckDetailId] IS NOT NULL");
        }
    }
}
