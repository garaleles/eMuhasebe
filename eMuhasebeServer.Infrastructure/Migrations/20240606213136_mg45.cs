using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetail_Expense_ExpenseId",
                table: "ExpenseDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseDetail",
                table: "ExpenseDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseDetail",
                newName: "ExpenseDetails");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseDetail_ExpenseId",
                table: "ExpenseDetails",
                newName: "IX_ExpenseDetails_ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseDetails",
                table: "ExpenseDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_Expenses_ExpenseId",
                table: "ExpenseDetails",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_Expenses_ExpenseId",
                table: "ExpenseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseDetails",
                table: "ExpenseDetails");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseDetails",
                newName: "ExpenseDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseDetails_ExpenseId",
                table: "ExpenseDetail",
                newName: "IX_ExpenseDetail_ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseDetail",
                table: "ExpenseDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetail_Expense_ExpenseId",
                table: "ExpenseDetail",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
