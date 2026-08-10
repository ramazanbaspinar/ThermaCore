using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class ApplyFinishedGoodConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinishedGoods_SpecialCode_SpecialCodeId",
                table: "FinishedGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishedGoods_Units_UnitId",
                table: "FinishedGoods");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesVatRate",
                table: "FinishedGoods",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesPrice",
                table: "FinishedGoods",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FinishedGoods",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FinishedGoods",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FinishedGoods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 59, 5, 793, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedGoods_SpecialCode_SpecialCodeId",
                table: "FinishedGoods",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedGoods_Units_UnitId",
                table: "FinishedGoods",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinishedGoods_SpecialCode_SpecialCodeId",
                table: "FinishedGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishedGoods_Units_UnitId",
                table: "FinishedGoods");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesVatRate",
                table: "FinishedGoods",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesPrice",
                table: "FinishedGoods",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FinishedGoods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FinishedGoods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FinishedGoods",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 10, 22, 57, 30, 912, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedGoods_SpecialCode_SpecialCodeId",
                table: "FinishedGoods",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedGoods_Units_UnitId",
                table: "FinishedGoods",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
