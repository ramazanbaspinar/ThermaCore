using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGasAndIgnitionGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasAndIgnitionGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GasAndIgnitionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasAndIgnitionGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasAndIgnitionGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_BaseUnitId",
                table: "GasAndIgnitionGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_BranchId",
                table: "GasAndIgnitionGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_CreatedDate",
                table: "GasAndIgnitionGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_IsActive",
                table: "GasAndIgnitionGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_IsDeleted",
                table: "GasAndIgnitionGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_SpecialCodeId",
                table: "GasAndIgnitionGroups",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasAndIgnitionGroups");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 18, 48, 33, 850, DateTimeKind.Local).AddTicks(1507));
        }
    }
}
