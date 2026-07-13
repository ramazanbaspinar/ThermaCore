using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGasValveModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasValves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GasType = table.Column<int>(type: "int", nullable: true),
                    HasSafetyValve = table.Column<bool>(type: "bit", nullable: false),
                    OutletAngle = table.Column<int>(type: "int", nullable: true),
                    ShaftType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_GasValves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasValves_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 13, 11, 22, 31, 693, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.CreateIndex(
                name: "IX_GasValves_Code",
                table: "GasValves",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasValves_CreatedDate",
                table: "GasValves",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GasValves_IsActive",
                table: "GasValves",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GasValves_IsDeleted",
                table: "GasValves",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GasValves_SpecialCodeId",
                table: "GasValves",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasValves");

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
        }
    }
}
