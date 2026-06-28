using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class MakeTaxRateDescriptionOptionalToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaxRates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2825));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaxRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 17, 27, 513, DateTimeKind.Local).AddTicks(9683));
        }
    }
}
