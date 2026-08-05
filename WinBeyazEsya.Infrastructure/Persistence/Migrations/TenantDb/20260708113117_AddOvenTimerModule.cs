using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddOvenTimerModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OvenTimers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    TimerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAmper = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_OvenTimers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvenTimers_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 31, 17, 262, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.CreateIndex(
                name: "IX_OvenTimers_Code",
                table: "OvenTimers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvenTimers_CreatedDate",
                table: "OvenTimers",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_OvenTimers_IsDeleted",
                table: "OvenTimers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OvenTimers_SpecialCodeId",
                table: "OvenTimers",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvenTimers");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 14, 14, 0, 758, DateTimeKind.Local).AddTicks(1872));
        }
    }
}

