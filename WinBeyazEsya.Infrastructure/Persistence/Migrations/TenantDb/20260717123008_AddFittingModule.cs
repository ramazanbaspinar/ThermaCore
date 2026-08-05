using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddFittingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fittings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FittingType = table.Column<int>(type: "int", nullable: true),
                    MaterialType = table.Column<int>(type: "int", nullable: true),
                    ThreadSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightGr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_Fittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fittings_SpecialCode_SpecialCodeId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Fittings_Code",
                table: "Fittings",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fittings_CreatedDate",
                table: "Fittings",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Fittings_IsActive",
                table: "Fittings",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Fittings_IsDeleted",
                table: "Fittings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Fittings_SpecialCodeId",
                table: "Fittings",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fittings");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 17, 14, 10, 38, 892, DateTimeKind.Local).AddTicks(540));
        }
    }
}

