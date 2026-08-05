using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class ChangeUnitConversionIdToLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [UnitConversions]");
            
            migrationBuilder.DropIndex(
                name: "IX_UnitConversions_EntityId",
                table: "UnitConversions");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "UnitConversions");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "UnitConversions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "UnitConversions");

            migrationBuilder.AddColumn<long>(
                name: "EntityId",
                table: "UnitConversions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_EntityId",
                table: "UnitConversions",
                column: "EntityId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "UnitConversions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "EntityId",
                table: "UnitConversions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 22, 10, 37, 14, 489, DateTimeKind.Local).AddTicks(7056));
        }
    }
}

