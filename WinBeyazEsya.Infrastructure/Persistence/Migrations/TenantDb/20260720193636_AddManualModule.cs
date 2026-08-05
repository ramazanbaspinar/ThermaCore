using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddManualModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManualType = table.Column<int>(type: "int", nullable: true),
                    PaperType = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<int>(type: "int", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Manuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manuals_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 22, 36, 35, 993, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.CreateIndex(
                name: "IX_Manuals_Code",
                table: "Manuals",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manuals_CreatedDate",
                table: "Manuals",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Manuals_IsActive",
                table: "Manuals",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Manuals_IsDeleted",
                table: "Manuals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Manuals_SpecialCodeId",
                table: "Manuals",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manuals");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 20, 16, 13, 37, 4, DateTimeKind.Local).AddTicks(9109));
        }
    }
}

