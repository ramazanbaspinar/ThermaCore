using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddPlasticPartModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlasticParts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    PlasticPartCategory = table.Column<int>(type: "int", nullable: true),
                    PlasticMaterialType = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightGr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PlasticParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlasticParts_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 19, 21, 59, 29, 547, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.CreateIndex(
                name: "IX_PlasticParts_Code",
                table: "PlasticParts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticParts_CreatedDate",
                table: "PlasticParts",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticParts_IsActive",
                table: "PlasticParts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticParts_IsDeleted",
                table: "PlasticParts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticParts_SpecialCodeId",
                table: "PlasticParts",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlasticParts");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 15, 30, 7, 469, DateTimeKind.Local).AddTicks(8953));
        }
    }
}

