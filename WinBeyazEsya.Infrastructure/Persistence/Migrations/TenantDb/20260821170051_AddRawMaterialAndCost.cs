using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddRawMaterialAndCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCost",
                table: "MaterialCost");

            migrationBuilder.RenameTable(
                name: "MaterialCost",
                newName: "MaterialCosts");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_IsDeleted",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_CreatedDate",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_Code",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCosts",
                table: "MaterialCosts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialGroup = table.Column<int>(type: "int", nullable: false),
                    CustomCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomCode3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomCode4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomCode5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurfaceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coating = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 20, 0, 51, 126, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_Code",
                table: "RawMaterials",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_CreatedDate",
                table: "RawMaterials",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_IsDeleted",
                table: "RawMaterials",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCosts",
                table: "MaterialCosts");

            migrationBuilder.RenameTable(
                name: "MaterialCosts",
                newName: "MaterialCost");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_IsDeleted",
                table: "MaterialCost",
                newName: "IX_MaterialCost_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_CreatedDate",
                table: "MaterialCost",
                newName: "IX_MaterialCost_CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_Code",
                table: "MaterialCost",
                newName: "IX_MaterialCost_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCost",
                table: "MaterialCost",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 21, 14, 25, 13, 566, DateTimeKind.Local).AddTicks(1727));
        }
    }
}
