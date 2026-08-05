using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddKnobModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShaftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Knobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knobs_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 9, 42, 50, 252, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.CreateIndex(
                name: "IX_Knobs_Code",
                table: "Knobs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knobs_CreatedDate",
                table: "Knobs",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Knobs_IsActive",
                table: "Knobs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Knobs_IsDeleted",
                table: "Knobs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Knobs_SpecialCodeId",
                table: "Knobs",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knobs");

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
        }
    }
}

