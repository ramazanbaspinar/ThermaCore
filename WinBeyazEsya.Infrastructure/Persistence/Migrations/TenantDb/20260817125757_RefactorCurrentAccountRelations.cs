using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class RefactorCurrentAccountRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccounts1",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts2",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts3",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts4",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts5",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts6",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccounts7",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs1",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs2",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs3",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs4",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs5",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs6",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "BankBranchs7",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CCurrency",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CyphCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "DeliveryFirm",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "DiscRate",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "District",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "FaxNr",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "TaxOffCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "TownCode",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "TownName",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "VatNr",
                table: "CurrentAccounts");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "CurrentAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "CurrentAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TownId",
                table: "CurrentAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 15, 57, 57, 463, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CityId",
                table: "CurrentAccounts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CountryId",
                table: "CurrentAccounts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_TownId",
                table: "CurrentAccounts",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAccounts_Cities_CityId",
                table: "CurrentAccounts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAccounts_Countries_CountryId",
                table: "CurrentAccounts",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAccounts_Towns_TownId",
                table: "CurrentAccounts",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAccounts_Cities_CityId",
                table: "CurrentAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAccounts_Countries_CountryId",
                table: "CurrentAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAccounts_Towns_TownId",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_CityId",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_CountryId",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_TownId",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "CurrentAccounts");

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts1",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts2",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts3",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts4",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts5",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts6",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccounts7",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs1",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs2",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs3",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs4",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs5",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs6",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranchs7",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CCurrency",
                table: "CurrentAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CurrentAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyphCode",
                table: "CurrentAccounts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryFirm",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryMethod",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscRate",
                table: "CurrentAccounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "CurrentAccounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaxNr",
                table: "CurrentAccounts",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "CurrentAccounts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOffCode",
                table: "CurrentAccounts",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TownCode",
                table: "CurrentAccounts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TownName",
                table: "CurrentAccounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatNr",
                table: "CurrentAccounts",
                type: "nvarchar(33)",
                maxLength: 33,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 14, 14, 38, 209, DateTimeKind.Local).AddTicks(3580));
        }
    }
}
