using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddWarehousesToProductRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConsumeWarehouseId",
                table: "ProductRecipes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EntryWarehouseId",
                table: "ProductRecipes",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 22, 29, 59, 647, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_ConsumeWarehouseId",
                table: "ProductRecipes",
                column: "ConsumeWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_EntryWarehouseId",
                table: "ProductRecipes",
                column: "EntryWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipes_Warehouses_ConsumeWarehouseId",
                table: "ProductRecipes",
                column: "ConsumeWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipes_Warehouses_EntryWarehouseId",
                table: "ProductRecipes",
                column: "EntryWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipes_Warehouses_ConsumeWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipes_Warehouses_EntryWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductRecipes_ConsumeWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductRecipes_EntryWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.DropColumn(
                name: "ConsumeWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.DropColumn(
                name: "EntryWarehouseId",
                table: "ProductRecipes");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3114));
        }
    }
}
