using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddOvenFanModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OvenFans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FanType = table.Column<int>(type: "int", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiameterMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BladeCount = table.Column<int>(type: "int", nullable: true),
                    ShaftHoleMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_OvenFans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvenFans_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 11, 22, 49, 4, 945, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.CreateIndex(
                name: "IX_OvenFans_Code",
                table: "OvenFans",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvenFans_CreatedDate",
                table: "OvenFans",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_OvenFans_IsActive",
                table: "OvenFans",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_OvenFans_IsDeleted",
                table: "OvenFans",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OvenFans_SpecialCodeId",
                table: "OvenFans",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvenFans");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 22, 27, 43, 924, DateTimeKind.Local).AddTicks(7543));
        }
    }
}

