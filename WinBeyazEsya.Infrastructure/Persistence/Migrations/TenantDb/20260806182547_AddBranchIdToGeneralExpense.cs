using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddBranchIdToGeneralExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "GeneralExpenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 21, 25, 46, 668, DateTimeKind.Local).AddTicks(7570));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "GeneralExpenses");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 6, 14, 30, 21, 846, DateTimeKind.Local).AddTicks(4860));
        }
    }
}
