using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddPackagingAndPrintingGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackagingAndPrintingGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_PackagingAndPrintingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 22, 33, 55, 10, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_BaseUnitId",
                table: "PackagingAndPrintingGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_Code",
                table: "PackagingAndPrintingGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_CreatedDate",
                table: "PackagingAndPrintingGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_IsActive",
                table: "PackagingAndPrintingGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_IsDeleted",
                table: "PackagingAndPrintingGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_SpecialCodeId",
                table: "PackagingAndPrintingGroups",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagingAndPrintingGroups");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 8, 21, 13, 24, 553, DateTimeKind.Local).AddTicks(3278));
        }
    }
}
