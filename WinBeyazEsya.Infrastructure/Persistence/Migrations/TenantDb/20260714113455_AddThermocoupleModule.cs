using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddThermocoupleModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thermocouples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthMm = table.Column<int>(type: "int", nullable: true),
                    HeadType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Thermocouples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thermocouples_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 14, 34, 55, 89, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.CreateIndex(
                name: "IX_Thermocouples_Code",
                table: "Thermocouples",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Thermocouples_CreatedDate",
                table: "Thermocouples",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Thermocouples_IsActive",
                table: "Thermocouples",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Thermocouples_IsDeleted",
                table: "Thermocouples",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Thermocouples_SpecialCodeId",
                table: "Thermocouples",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thermocouples");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 14, 10, 56, 32, 348, DateTimeKind.Local).AddTicks(3075));
        }
    }
}

