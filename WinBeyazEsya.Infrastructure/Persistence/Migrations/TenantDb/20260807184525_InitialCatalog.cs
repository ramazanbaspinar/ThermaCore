using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostParameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MaturityDifferenceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WastageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageProductionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_CostParameters", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "GeneralExpenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GeneralExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBarcodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BarcodeValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BarcodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    QuantityPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_ItemBarcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialCost",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialType = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_MaterialCost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CodeType = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_SpecialCode", x => x.Id);
                });

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
                    CompanyBarcodePrefix = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GuncellemeYolu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetalSheetGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    SurfaceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QualityCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_MetalSheetGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetalSheetGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetalSheetGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitConversions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Divisor = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    IsMainUnit = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_UnitConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitConversions_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Description", "IsActive", "IsDeleted", "ModifiedDate", "ModifiedUserId", "Name" },
                values: new object[,]
                {
                    { 1L, "AD", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7059), 1L, null, null, null, true, false, null, null, "Adet" },
                    { 2L, "KG", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7077), 1L, null, null, null, true, false, null, null, "Kilogram" },
                    { 3L, "GR", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7078), 1L, null, null, null, true, false, null, null, "Gram" },
                    { 4L, "LT", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7080), 1L, null, null, null, true, false, null, null, "Litre" },
                    { 5L, "MT", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7081), 1L, null, null, null, true, false, null, null, "Metre" },
                    { 6L, "CM", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7082), 1L, null, null, null, true, false, null, null, "Santimetre" },
                    { 7L, "MM", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7083), 1L, null, null, null, true, false, null, null, "Milimetre" },
                    { 8L, "PK", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7090), 1L, null, null, null, true, false, null, null, "Paket" },
                    { 9L, "KL", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7091), 1L, null, null, null, true, false, null, null, "Koli" },
                    { 10L, "TON", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7079), 1L, null, null, null, true, false, null, null, "Ton" },
                    { 11L, "TK", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7093), 1L, null, null, null, true, false, null, null, "Takım" },
                    { 12L, "CU", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7101), 1L, null, null, null, true, false, null, null, "Çuval" },
                    { 13L, "KM", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7084), 1L, null, null, null, true, false, null, null, "Kilometre" },
                    { 14L, "M2", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7085), 1L, null, null, null, true, false, null, null, "Metrekare" },
                    { 15L, "CM2", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7086), 1L, null, null, null, true, false, null, null, "Santimetrekare" },
                    { 16L, "M3", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7087), 1L, null, null, null, true, false, null, null, "Metreküp" },
                    { 17L, "MIC", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7088), 1L, null, null, null, true, false, null, null, "Mikron" },
                    { 18L, "GR/M2", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7088), 1L, null, null, null, true, false, null, null, "Gram/Metrekare" },
                    { 19L, "KG/M2", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7089), 1L, null, null, null, true, false, null, null, "Kilogram/Metrekare" },
                    { 20L, "KUT", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7092), 1L, null, null, null, true, false, null, null, "Kutu" },
                    { 21L, "TBK", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7100), 1L, null, null, null, true, false, null, null, "Tabaka" },
                    { 22L, "BDN", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7102), 1L, null, null, null, true, false, null, null, "Bidon" },
                    { 23L, "TNK", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7103), 1L, null, null, null, true, false, null, null, "Teneke" },
                    { 24L, "KOV", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7104), 1L, null, null, null, true, false, null, null, "Kova" },
                    { 25L, "DZ", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7105), 1L, null, null, null, true, false, null, null, "Düzine" },
                    { 26L, "DST", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7106), 1L, null, null, null, true, false, null, null, "Deste" },
                    { 27L, "OHM", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7107), 1L, null, null, null, true, false, null, null, "Ohm" },
                    { 28L, "KW", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7108), 1L, null, null, null, true, false, null, null, "Kilowatt" },
                    { 29L, "W", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7109), 1L, null, null, null, true, false, null, null, "Watt" },
                    { 30L, "SN", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7110), 1L, null, null, null, true, false, null, null, "Saniye" },
                    { 31L, "DK", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7111), 1L, null, null, null, true, false, null, null, "Dakika" },
                    { 32L, "SA", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7112), 1L, null, null, null, true, false, null, null, "Saat" },
                    { 33L, "GUN", new DateTime(2026, 8, 7, 21, 45, 25, 230, DateTimeKind.Local).AddTicks(7113), 1L, null, null, null, true, false, null, null, "Gün" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDocuments_CreatedDate",
                table: "AppDocuments",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_AppDocuments_EntityName_EntityId",
                table: "AppDocuments",
                columns: new[] { "EntityName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_CostParameters_CreatedDate",
                table: "CostParameters",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_CostParameters_IsDeleted",
                table: "CostParameters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CreatedDate",
                table: "ExchangeRates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_IsDeleted",
                table: "ExchangeRates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_CreatedDate",
                table: "GeneralExpenses",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_IsDeleted",
                table: "GeneralExpenses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcodes_CreatedDate",
                table: "ItemBarcodes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcodes_IsDeleted",
                table: "ItemBarcodes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCost_Code",
                table: "MaterialCost",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCost_CreatedDate",
                table: "MaterialCost",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCost_IsDeleted",
                table: "MaterialCost",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_BaseUnitId",
                table: "MetalSheetGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_BranchId",
                table: "MetalSheetGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_CreatedDate",
                table: "MetalSheetGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_IsActive",
                table: "MetalSheetGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_IsDeleted",
                table: "MetalSheetGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_SpecialCodeId",
                table: "MetalSheetGroups",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_Code",
                table: "SpecialCode",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_CodeType_EntityType_Code",
                table: "SpecialCode",
                columns: new[] { "CodeType", "EntityType", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_CreatedDate",
                table: "SpecialCode",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCode_IsDeleted",
                table: "SpecialCode",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_CreatedDate",
                table: "SystemParameters",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_IsDeleted",
                table: "SystemParameters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_Code",
                table: "TaxRates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_CreatedDate",
                table: "TaxRates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_IsActive",
                table: "TaxRates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_IsDeleted",
                table: "TaxRates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_CreatedDate",
                table: "UnitConversions",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_EntityId",
                table: "UnitConversions",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_IsDeleted",
                table: "UnitConversions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_UnitId",
                table: "UnitConversions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Code",
                table: "Units",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_CreatedDate",
                table: "Units",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Units_IsActive",
                table: "Units",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Units_IsDeleted",
                table: "Units",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDocuments");

            migrationBuilder.DropTable(
                name: "CostParameters");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "GeneralExpenses");

            migrationBuilder.DropTable(
                name: "ItemBarcodes");

            migrationBuilder.DropTable(
                name: "MaterialCost");

            migrationBuilder.DropTable(
                name: "MetalSheetGroups");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "UnitConversions");

            migrationBuilder.DropTable(
                name: "SpecialCode");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
