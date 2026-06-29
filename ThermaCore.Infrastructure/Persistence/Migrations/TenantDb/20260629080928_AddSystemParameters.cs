using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddSystemParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LocalCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DefaultPurchaseKdvId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultSalesKdvId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultOtvId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultWastageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_SystemParameters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2637));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 29, 11, 9, 27, 885, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_CreatedDate",
                table: "SystemParameters",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_IsDeleted",
                table: "SystemParameters",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 28, 21, 41, 11, 70, DateTimeKind.Local).AddTicks(2825));
        }
    }
}
