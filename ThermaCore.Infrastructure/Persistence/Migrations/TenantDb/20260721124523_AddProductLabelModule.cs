using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddProductLabelModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductLabels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelType = table.Column<int>(type: "int", nullable: true),
                    LabelMaterialType = table.Column<int>(type: "int", nullable: true),
                    WidthMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HeightMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ProductLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLabels_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 21, 15, 45, 22, 387, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabels_Code",
                table: "ProductLabels",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabels_CreatedDate",
                table: "ProductLabels",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabels_IsActive",
                table: "ProductLabels",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabels_IsDeleted",
                table: "ProductLabels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabels_SpecialCodeId",
                table: "ProductLabels",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLabels");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(328));
        }
    }
}
