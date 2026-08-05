using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddRotarySwitchModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RotarySwitches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAmper = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RotarySwitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotarySwitches_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 8, 10, 16, 29, 177, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.CreateIndex(
                name: "IX_RotarySwitches_Code",
                table: "RotarySwitches",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RotarySwitches_CreatedDate",
                table: "RotarySwitches",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_RotarySwitches_IsActive",
                table: "RotarySwitches",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RotarySwitches_IsDeleted",
                table: "RotarySwitches",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RotarySwitches_SpecialCodeId",
                table: "RotarySwitches",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotarySwitches");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 7, 20, 47, 42, 507, DateTimeKind.Local).AddTicks(5050));
        }
    }
}

