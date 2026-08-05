using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddHotplateModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HotplateType = table.Column<int>(type: "int", nullable: true),
                    DiameterMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PowerWatt = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Hotplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotplates_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 10, 10, 18, 54, 122, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.CreateIndex(
                name: "IX_Hotplates_Code",
                table: "Hotplates",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotplates_CreatedDate",
                table: "Hotplates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Hotplates_IsActive",
                table: "Hotplates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Hotplates_IsDeleted",
                table: "Hotplates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Hotplates_SpecialCodeId",
                table: "Hotplates",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotplates");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 16, 14, 20, 881, DateTimeKind.Local).AddTicks(811));
        }
    }
}

