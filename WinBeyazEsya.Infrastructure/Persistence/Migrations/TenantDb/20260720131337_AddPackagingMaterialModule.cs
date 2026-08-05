using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddPackagingMaterialModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackagingMaterials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PackagingType = table.Column<int>(type: "int", nullable: true),
                    PackagingMaterialType = table.Column<int>(type: "int", nullable: true),
                    ThicknessMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_PackagingMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagingMaterials_SpecialCode_SpecialCodeId",
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

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMaterials_Code",
                table: "PackagingMaterials",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMaterials_CreatedDate",
                table: "PackagingMaterials",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMaterials_IsActive",
                table: "PackagingMaterials",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMaterials_IsDeleted",
                table: "PackagingMaterials",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingMaterials_SpecialCodeId",
                table: "PackagingMaterials",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagingMaterials");

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
        }
    }
}

