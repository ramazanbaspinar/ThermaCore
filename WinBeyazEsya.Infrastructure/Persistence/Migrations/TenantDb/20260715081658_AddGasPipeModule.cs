using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGasPipeModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasPipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BranchCount = table.Column<int>(type: "int", nullable: true),
                    PipeType = table.Column<int>(type: "int", nullable: true),
                    GasType = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_GasPipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasPipes_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 902, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 902, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 902, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 902, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 902, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(63));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 15, 11, 16, 57, 903, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.CreateIndex(
                name: "IX_GasPipes_Code",
                table: "GasPipes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GasPipes_CreatedDate",
                table: "GasPipes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GasPipes_IsActive",
                table: "GasPipes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GasPipes_IsDeleted",
                table: "GasPipes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GasPipes_SpecialCodeId",
                table: "GasPipes",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasPipes");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 23, 6, 7, 588, DateTimeKind.Local).AddTicks(183));
        }
    }
}

