using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickReserve.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _0006_Added_CompanyLogoImage_Column_To_CompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoImage",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 24, 15, 9, 51, 689, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 24, 15, 9, 51, 689, DateTimeKind.Utc).AddTicks(8083));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "Companies");

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
    }
}
