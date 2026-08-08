using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddPlasticAndVisualPartsGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlasticAndVisualPartsGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    table.PrimaryKey("PK_PlasticAndVisualPartsGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlasticAndVisualPartsGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlasticAndVisualPartsGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 20, 10, 6, 797, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_BaseUnitId",
                table: "PlasticAndVisualPartsGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_BranchId",
                table: "PlasticAndVisualPartsGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_CreatedDate",
                table: "PlasticAndVisualPartsGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_IsActive",
                table: "PlasticAndVisualPartsGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_IsDeleted",
                table: "PlasticAndVisualPartsGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_SpecialCodeId",
                table: "PlasticAndVisualPartsGroups",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlasticAndVisualPartsGroups");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 19, 33, 12, 913, DateTimeKind.Local).AddTicks(2204));
        }
    }
}
