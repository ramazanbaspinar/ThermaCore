using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddProductRecipeLineDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CoatingAmount",
                table: "ProductRecipeLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CoatingMaterialId",
                table: "ProductRecipeLines",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "ProductRecipeLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductRecipeLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualCoatingCost",
                table: "ProductRecipeLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                table: "ProductRecipeLines",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurfaceCoatingType",
                table: "ProductRecipeLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMaterialCost",
                table: "ProductRecipeLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProductRecipeLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightKg",
                table: "ProductRecipeLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 11, 54, 39, 691, DateTimeKind.Local).AddTicks(9354));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoatingAmount",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "CoatingMaterialId",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "ManualCoatingCost",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "SurfaceCoatingType",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "TotalMaterialCost",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProductRecipeLines");

            migrationBuilder.DropColumn(
                name: "WeightKg",
                table: "ProductRecipeLines");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 16, 9, 37, 2, 127, DateTimeKind.Local).AddTicks(4041));
        }
    }
}
