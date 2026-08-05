using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddSparkPlugModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SparkPlugs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SparkTipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SparkPlugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SparkPlugs_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 16, 5, 18, 903, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.CreateIndex(
                name: "IX_SparkPlugs_Code",
                table: "SparkPlugs",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_SparkPlugs_CreatedDate",
                table: "SparkPlugs",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SparkPlugs_IsActive",
                table: "SparkPlugs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SparkPlugs_IsDeleted",
                table: "SparkPlugs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SparkPlugs_SpecialCodeId",
                table: "SparkPlugs",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparkPlugs");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 15, 10, 25, 517, DateTimeKind.Local).AddTicks(1980));
        }
    }
}

