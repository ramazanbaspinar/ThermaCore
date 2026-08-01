using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGenelGiderler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenelGiderler",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelGiderler", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 1, 16, 55, 54, 708, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_UnitId",
                table: "UnitConversions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GenelGiderler_Code",
                table: "GenelGiderler",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GenelGiderler_CreatedDate",
                table: "GenelGiderler",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GenelGiderler_IsDeleted",
                table: "GenelGiderler",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConversions_Units_UnitId",
                table: "UnitConversions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitConversions_Units_UnitId",
                table: "UnitConversions");

            migrationBuilder.DropTable(
                name: "GenelGiderler");

            migrationBuilder.DropIndex(
                name: "IX_UnitConversions_UnitId",
                table: "UnitConversions");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 23, 13, 32, 3, 636, DateTimeKind.Local).AddTicks(8651));
        }
    }
}
