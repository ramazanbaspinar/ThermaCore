using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddValveModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valve",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValveType = table.Column<int>(type: "int", nullable: true),
                    GasType = table.Column<int>(type: "int", nullable: true),
                    MaxPressureMbar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConnectionSize = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TemperatureRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_Valve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valve_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.CreateIndex(
                name: "IX_Valve_Code",
                table: "Valve",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Valve_CreatedDate",
                table: "Valve",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Valve_IsActive",
                table: "Valve",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Valve_IsDeleted",
                table: "Valve",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Valve_SpecialCodeId",
                table: "Valve",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valve");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 16, 49, 23, 87, DateTimeKind.Local).AddTicks(1561));
        }
    }
}

