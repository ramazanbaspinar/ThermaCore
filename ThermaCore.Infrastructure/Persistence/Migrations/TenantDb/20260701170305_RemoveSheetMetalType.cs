using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class RemoveSheetMetalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetMetals_SheetMetalTypes_SheetMetalTypeId",
                table: "SheetMetals");

            migrationBuilder.DropTable(
                name: "SheetMetalTypes");

            migrationBuilder.DropIndex(
                name: "IX_SheetMetals_SheetMetalTypeId",
                table: "SheetMetals");

            migrationBuilder.DropColumn(
                name: "SheetMetalTypeId",
                table: "SheetMetals");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5778));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 20, 3, 4, 61, DateTimeKind.Local).AddTicks(5869));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SheetMetalTypeId",
                table: "SheetMetals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SheetMetalTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetMetalTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 1, 15, 13, 24, 386, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_SheetMetalTypeId",
                table: "SheetMetals",
                column: "SheetMetalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetalTypes_Code",
                table: "SheetMetalTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetalTypes_CreatedDate",
                table: "SheetMetalTypes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetalTypes_IsActive",
                table: "SheetMetalTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetalTypes_IsDeleted",
                table: "SheetMetalTypes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMetals_SheetMetalTypes_SheetMetalTypeId",
                table: "SheetMetals",
                column: "SheetMetalTypeId",
                principalTable: "SheetMetalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
