using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddGuncellemeYoluToSystemParameter_Tenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuncellemeYolu",
                table: "SystemParameters",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 13, 34, 3, 675, DateTimeKind.Local).AddTicks(3100));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuncellemeYolu",
                table: "SystemParameters");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 10, 46, 32, 169, DateTimeKind.Local).AddTicks(7570));
        }
    }
}

