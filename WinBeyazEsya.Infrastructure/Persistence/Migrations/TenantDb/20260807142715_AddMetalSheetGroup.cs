using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddMetalSheetGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetalSheetGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    SurfaceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_MetalSheetGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetalSheetGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MetalSheetGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 7, 17, 27, 15, 1, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_BaseUnitId",
                table: "MetalSheetGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_CreatedDate",
                table: "MetalSheetGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_IsActive",
                table: "MetalSheetGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_IsDeleted",
                table: "MetalSheetGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_SpecialCodeId",
                table: "MetalSheetGroups",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetalSheetGroups");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 53, 42, 25, DateTimeKind.Local).AddTicks(1122));
        }
    }
}
