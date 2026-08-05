using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddInsulationModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insulations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsulationType = table.Column<int>(type: "int", nullable: true),
                    ThicknessMm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Density = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_Insulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insulations_SpecialCode_SpecialCodeId",
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
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 11, 39, 51, 476, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.CreateIndex(
                name: "IX_Insulations_Code",
                table: "Insulations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insulations_CreatedDate",
                table: "Insulations",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Insulations_IsActive",
                table: "Insulations",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Insulations_IsDeleted",
                table: "Insulations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Insulations_SpecialCodeId",
                table: "Insulations",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insulations");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 16, 10, 56, 41, 975, DateTimeKind.Local).AddTicks(8877));
        }
    }
}

