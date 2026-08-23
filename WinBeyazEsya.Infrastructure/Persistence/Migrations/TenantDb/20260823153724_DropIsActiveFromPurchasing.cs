using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class DropIsActiveFromPurchasing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PurchaseReceipts_IsActive",
                table: "PurchaseReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_IsActive",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchaseOrders");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 18, 37, 23, 213, DateTimeKind.Local).AddTicks(4941));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PurchaseReceipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PurchaseOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 12, 20, 48, 612, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipts_IsActive",
                table: "PurchaseReceipts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_IsActive",
                table: "PurchaseOrders",
                column: "IsActive");
        }
    }
}
