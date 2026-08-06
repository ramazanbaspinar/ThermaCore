using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class ApplyFullBranchIsolationToTenantDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "SpecialCode",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "MaterialCost",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "MaliyetParametreleri",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "ItemBarcodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "ColorFeature",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "AppDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1122));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SpecialCode");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "MaterialCost");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "MaliyetParametreleri");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ItemBarcodes");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ColorFeature");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AppDocuments");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7570));
        }
    }
}
