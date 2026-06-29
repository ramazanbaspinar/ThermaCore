using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddQualityStandardsToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityStandards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialGroup = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_QualityStandards", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 23, 30, 2, 3, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_Code",
                table: "QualityStandards",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_CreatedDate",
                table: "QualityStandards",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_IsActive",
                table: "QualityStandards",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_IsDeleted",
                table: "QualityStandards",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityStandards");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 22, 35, 44, 19, DateTimeKind.Local).AddTicks(8645));
        }
    }
}
