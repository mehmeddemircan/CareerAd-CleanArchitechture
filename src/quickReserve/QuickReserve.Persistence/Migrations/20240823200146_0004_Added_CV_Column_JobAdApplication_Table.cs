using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickReserve.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _0004_Added_CV_Column_JobAdApplication_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CvPdfPublicId",
                table: "JobAdApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CvPdfUrl",
                table: "JobAdApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvPdfPublicId",
                table: "JobAdApplications");

            migrationBuilder.DropColumn(
                name: "CvPdfUrl",
                table: "JobAdApplications");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 14, 33, 45, 224, DateTimeKind.Utc).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 14, 33, 45, 224, DateTimeKind.Utc).AddTicks(1221));
        }
    }
}
