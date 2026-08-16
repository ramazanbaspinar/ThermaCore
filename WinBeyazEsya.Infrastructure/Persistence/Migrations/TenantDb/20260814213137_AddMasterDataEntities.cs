using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddMasterDataEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
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
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SpeCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CyphCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Addr1 = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: true),
                    Addr2 = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: true),
                    City = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TelNrs1 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TelNrs2 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FaxNr = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TaxNr = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InCharge = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    DiscRate = table.Column<double>(type: "float", nullable: false),
                    PaymentRef = table.Column<long>(type: "bigint", nullable: false),
                    EmailAddr = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: true),
                    WebAddr = table.Column<string>(type: "nvarchar(41)", maxLength: 41, nullable: true),
                    VatNr = table.Column<string>(type: "nvarchar(33)", maxLength: 33, nullable: true),
                    BankBranchs1 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs2 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs3 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs4 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs5 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs6 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankBranchs7 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts1 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts2 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts3 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts4 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts5 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts6 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    BankAccounts7 = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    DeliveryFirm = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CCurrency = table.Column<int>(type: "int", nullable: false),
                    TaxOffCode = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    TownCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TownName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    District = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_CurrentAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TownCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
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
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 15, 0, 31, 36, 320, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Code",
                table: "Cities",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedDate",
                table: "Cities",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsActive",
                table: "Cities",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedDate",
                table: "Countries",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsActive",
                table: "Countries",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsDeleted",
                table: "Countries",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CreatedDate",
                table: "CurrentAccounts",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_IsActive",
                table: "CurrentAccounts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_IsDeleted",
                table: "CurrentAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_Code",
                table: "Towns",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CreatedDate",
                table: "Towns",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_IsActive",
                table: "Towns",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_IsDeleted",
                table: "Towns",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CurrentAccounts");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 12, 20, 38, 51, 300, DateTimeKind.Local).AddTicks(9571));
        }
    }
}
