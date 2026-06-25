using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddNewUnitSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Description", "IsActive", "IsDeleted", "ModifiedDate", "ModifiedUserId", "Name" },
                values: new object[,]
                {
                    { 13L, "KM", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3885), 1L, null, null, null, true, false, null, null, "Kilometre" },
                    { 14L, "M2", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3886), 1L, null, null, null, true, false, null, null, "Metrekare" },
                    { 15L, "CM2", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3887), 1L, null, null, null, true, false, null, null, "Santimetrekare" },
                    { 16L, "M3", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3888), 1L, null, null, null, true, false, null, null, "Metreküp" },
                    { 17L, "MIC", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3889), 1L, null, null, null, true, false, null, null, "Mikron" },
                    { 18L, "GR/M2", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3890), 1L, null, null, null, true, false, null, null, "Gram/Metrekare" },
                    { 19L, "KG/M2", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3891), 1L, null, null, null, true, false, null, null, "Kilogram/Metrekare" },
                    { 20L, "KUT", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3894), 1L, null, null, null, true, false, null, null, "Kutu" },
                    { 21L, "TBK", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3896), 1L, null, null, null, true, false, null, null, "Tabaka" },
                    { 22L, "BDN", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3898), 1L, null, null, null, true, false, null, null, "Bidon" },
                    { 23L, "TNK", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3899), 1L, null, null, null, true, false, null, null, "Teneke" },
                    { 24L, "KOV", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3900), 1L, null, null, null, true, false, null, null, "Kova" },
                    { 25L, "DZ", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3900), 1L, null, null, null, true, false, null, null, "Düzine" },
                    { 26L, "DST", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3901), 1L, null, null, null, true, false, null, null, "Deste" },
                    { 27L, "OHM", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3902), 1L, null, null, null, true, false, null, null, "Ohm" },
                    { 28L, "KW", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3903), 1L, null, null, null, true, false, null, null, "Kilowatt" },
                    { 29L, "W", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3904), 1L, null, null, null, true, false, null, null, "Watt" },
                    { 30L, "SN", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3905), 1L, null, null, null, true, false, null, null, "Saniye" },
                    { 31L, "DK", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3906), 1L, null, null, null, true, false, null, null, "Dakika" },
                    { 32L, "SA", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3907), 1L, null, null, null, true, false, null, null, "Saat" },
                    { 33L, "GUN", new DateTime(2026, 6, 25, 22, 37, 10, 695, DateTimeKind.Local).AddTicks(3908), 1L, null, null, null, true, false, null, null, "Gün" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3139));
        }
    }
}
