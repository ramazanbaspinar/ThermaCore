using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddExchangeRateToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EffectiveBuyingRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EffectiveSellingRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TcmbBuyingRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TcmbSellingRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 27, 14, 20, 10, 102, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CreatedDate",
                table: "ExchangeRates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_IsDeleted",
                table: "ExchangeRates",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3908));
        }
    }
}
