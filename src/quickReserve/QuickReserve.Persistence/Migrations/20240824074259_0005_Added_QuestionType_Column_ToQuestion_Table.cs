using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickReserve.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _0005_Added_QuestionType_Column_ToQuestion_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 24, 7, 42, 58, 968, DateTimeKind.Utc).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 24, 7, 42, 58, 968, DateTimeKind.Utc).AddTicks(2878));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 20, 1, 45, 906, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 20, 1, 45, 906, DateTimeKind.Utc).AddTicks(2330));
        }
    }
}
