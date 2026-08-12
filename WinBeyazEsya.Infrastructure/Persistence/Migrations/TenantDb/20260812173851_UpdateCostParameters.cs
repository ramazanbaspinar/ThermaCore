using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateCostParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageProductionValue",
                table: "CostParameters");

            migrationBuilder.AddColumn<int>(
                name: "BuiltInAvgMonthlyProduction",
                table: "CostParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CookerAvgMonthlyProduction",
                table: "CostParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreestandingAvgMonthlyProduction",
                table: "CostParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtherAvgMonthlyProduction",
                table: "CostParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OvenAvgMonthlyProduction",
                table: "CostParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UseMaturityDifference",
                table: "CostParameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseWasteRate",
                table: "CostParameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9571));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuiltInAvgMonthlyProduction",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "CookerAvgMonthlyProduction",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "FreestandingAvgMonthlyProduction",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "OtherAvgMonthlyProduction",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "OvenAvgMonthlyProduction",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "UseMaturityDifference",
                table: "CostParameters");

            migrationBuilder.DropColumn(
                name: "UseWasteRate",
                table: "CostParameters");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageProductionValue",
                table: "CostParameters",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 23, 46, 57, 693, DateTimeKind.Local).AddTicks(1013));
        }
    }
}
