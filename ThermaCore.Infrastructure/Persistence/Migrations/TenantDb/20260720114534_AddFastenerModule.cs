using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddFastenerModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fasteners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FastenerType = table.Column<int>(type: "int", nullable: true),
                    MaterialType = table.Column<int>(type: "int", nullable: true),
                    WeightGr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    QualityStandardId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Fasteners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fasteners_QualityStandards_QualityStandardId",
                        column: x => x.QualityStandardId,
                        principalTable: "QualityStandards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fasteners_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 880, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 881, DateTimeKind.Local).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 881, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 14, 45, 32, 881, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_Code",
                table: "Fasteners",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_CreatedDate",
                table: "Fasteners",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_IsActive",
                table: "Fasteners",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_IsDeleted",
                table: "Fasteners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_QualityStandardId",
                table: "Fasteners",
                column: "QualityStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Fasteners_SpecialCodeId",
                table: "Fasteners",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fasteners");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 10, 59, 32, 112, DateTimeKind.Local).AddTicks(9862));
        }
    }
}
