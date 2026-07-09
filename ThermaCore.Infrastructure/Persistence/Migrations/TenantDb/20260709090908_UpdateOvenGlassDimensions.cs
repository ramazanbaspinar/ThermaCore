using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateOvenGlassDimensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "OvenGlasses");

            migrationBuilder.AddColumn<decimal>(
                name: "HeightMm",
                table: "OvenGlasses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WidthMm",
                table: "OvenGlasses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 12, 9, 7, 818, DateTimeKind.Local).AddTicks(772));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightMm",
                table: "OvenGlasses");

            migrationBuilder.DropColumn(
                name: "WidthMm",
                table: "OvenGlasses");

            migrationBuilder.AddColumn<string>(
                name: "Dimensions",
                table: "OvenGlasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7726));
        }
    }
}
