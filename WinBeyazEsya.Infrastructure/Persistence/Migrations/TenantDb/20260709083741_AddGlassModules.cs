using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGlassModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ColorFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvenGlasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThicknessMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    GlassTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ColorFeatureId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_OvenGlasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvenGlasses_ColorFeatures_ColorFeatureId",
                        column: x => x.ColorFeatureId,
                        principalTable: "ColorFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OvenGlasses_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OvenGlasses_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 11, 37, 40, 988, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.CreateIndex(
                name: "IX_ColorFeatures_Code",
                table: "ColorFeatures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColorFeatures_CreatedDate",
                table: "ColorFeatures",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ColorFeatures_IsActive",
                table: "ColorFeatures",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ColorFeatures_IsDeleted",
                table: "ColorFeatures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_Code",
                table: "GlassTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_CreatedDate",
                table: "GlassTypes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_IsActive",
                table: "GlassTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_IsDeleted",
                table: "GlassTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_Code",
                table: "OvenGlasses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_ColorFeatureId",
                table: "OvenGlasses",
                column: "ColorFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_CreatedDate",
                table: "OvenGlasses",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_GlassTypeId",
                table: "OvenGlasses",
                column: "GlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_IsActive",
                table: "OvenGlasses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_IsDeleted",
                table: "OvenGlasses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OvenGlasses_SpecialCodeId",
                table: "OvenGlasses",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvenGlasses");

            migrationBuilder.DropTable(
                name: "ColorFeatures");

            migrationBuilder.DropTable(
                name: "GlassTypes");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 9, 10, 13, 37, 713, DateTimeKind.Local).AddTicks(1453));
        }
    }
}

