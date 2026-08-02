using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateMaterialCostToFullAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MaterialCosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedUserId",
                table: "MaterialCosts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MaterialCosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedUserId",
                table: "MaterialCosts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaterialCosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "MaterialCosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedUserId",
                table: "MaterialCosts",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 22, 17, 39, 786, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCosts_CreatedDate",
                table: "MaterialCosts",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCosts_IsDeleted",
                table: "MaterialCosts",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaterialCosts_CreatedDate",
                table: "MaterialCosts");

            migrationBuilder.DropIndex(
                name: "IX_MaterialCosts_IsDeleted",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "MaterialCosts");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "MaterialCosts");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 2, 21, 13, 42, 616, DateTimeKind.Local).AddTicks(273));
        }
    }
}
