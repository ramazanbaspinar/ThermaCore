using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddSpecialCodesAndUpdateSac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupCodeId",
                table: "SheetMetals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SpecialCodeId",
                table: "SheetMetals",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecialCode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CodeType = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_SpecialCode", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 15, 28, 8, 51, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_GroupCodeId",
                table: "SheetMetals",
                column: "GroupCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_SpecialCodeId",
                table: "SheetMetals",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_Code",
                table: "SpecialCode",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_CodeType_EntityType_Code",
                table: "SpecialCode",
                columns: new[] { "CodeType", "EntityType", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_CreatedDate",
                table: "SpecialCode",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_IsDeleted",
                table: "SpecialCode",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMetals_SpecialCode_GroupCodeId",
                table: "SheetMetals",
                column: "GroupCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetMetals_SpecialCode_SpecialCodeId",
                table: "SheetMetals",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetMetals_SpecialCode_GroupCodeId",
                table: "SheetMetals");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetMetals_SpecialCode_SpecialCodeId",
                table: "SheetMetals");

            migrationBuilder.DropTable(
                name: "SpecialCode");

            migrationBuilder.DropIndex(
                name: "IX_SheetMetals_GroupCodeId",
                table: "SheetMetals");

            migrationBuilder.DropIndex(
                name: "IX_SheetMetals_SpecialCodeId",
                table: "SheetMetals");

            migrationBuilder.DropColumn(
                name: "GroupCodeId",
                table: "SheetMetals");

            migrationBuilder.DropColumn(
                name: "SpecialCodeId",
                table: "SheetMetals");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 2, 13, 55, 7, 25, DateTimeKind.Local).AddTicks(4644));
        }
    }
}
