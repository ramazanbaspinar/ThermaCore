using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
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
                name: "QualityStandards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialGroup = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_QualityStandards", x => x.Id);
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
                name: "SurfaceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_SurfaceTypes", x => x.Id);
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
                name: "Boyas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeatResistance = table.Column<int>(type: "int", nullable: true),
                    DryingTimeMinutes = table.Column<int>(type: "int", nullable: true),
                    ShelfLifeMonths = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Boyas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boyas_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emayes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Emayes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emayes_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screws",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Diameter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LengthMm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Screws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screws_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheetMetals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QualityStandardId = table.Column<long>(type: "bigint", nullable: false),
                    SurfaceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Density = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 7.85m),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    GroupCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_SheetMetals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetMetals_QualityStandards_QualityStandardId",
                        column: x => x.QualityStandardId,
                        principalTable: "QualityStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetMetals_SpecialCode_GroupCodeId",
                        column: x => x.GroupCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetMetals_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetMetals_SurfaceTypes_SurfaceTypeId",
                        column: x => x.SurfaceTypeId,
                        principalTable: "SurfaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetMetals_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Description", "IsActive", "IsDeleted", "ModifiedDate", "ModifiedUserId", "Name" },
                values: new object[,]
                {
                    { 1L, "AD", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4059), 1L, null, null, null, true, false, null, null, "Adet" },
                    { 2L, "KG", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4078), 1L, null, null, null, true, false, null, null, "Kilogram" },
                    { 3L, "GR", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4080), 1L, null, null, null, true, false, null, null, "Gram" },
                    { 4L, "LT", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4082), 1L, null, null, null, true, false, null, null, "Litre" },
                    { 5L, "MT", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4083), 1L, null, null, null, true, false, null, null, "Metre" },
                    { 6L, "CM", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4084), 1L, null, null, null, true, false, null, null, "Santimetre" },
                    { 7L, "MM", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4085), 1L, null, null, null, true, false, null, null, "Milimetre" },
                    { 8L, "PK", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4094), 1L, null, null, null, true, false, null, null, "Paket" },
                    { 9L, "KL", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4094), 1L, null, null, null, true, false, null, null, "Koli" },
                    { 10L, "TON", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4081), 1L, null, null, null, true, false, null, null, "Ton" },
                    { 11L, "TK", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4096), 1L, null, null, null, true, false, null, null, "Takım" },
                    { 12L, "CU", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4098), 1L, null, null, null, true, false, null, null, "Çuval" },
                    { 13L, "KM", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4086), 1L, null, null, null, true, false, null, null, "Kilometre" },
                    { 14L, "M2", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4087), 1L, null, null, null, true, false, null, null, "Metrekare" },
                    { 15L, "CM2", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4088), 1L, null, null, null, true, false, null, null, "Santimetrekare" },
                    { 16L, "M3", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4090), 1L, null, null, null, true, false, null, null, "Metreküp" },
                    { 17L, "MIC", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4091), 1L, null, null, null, true, false, null, null, "Mikron" },
                    { 18L, "GR/M2", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4092), 1L, null, null, null, true, false, null, null, "Gram/Metrekare" },
                    { 19L, "KG/M2", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4093), 1L, null, null, null, true, false, null, null, "Kilogram/Metrekare" },
                    { 20L, "KUT", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4095), 1L, null, null, null, true, false, null, null, "Kutu" },
                    { 21L, "TBK", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4097), 1L, null, null, null, true, false, null, null, "Tabaka" },
                    { 22L, "BDN", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4099), 1L, null, null, null, true, false, null, null, "Bidon" },
                    { 23L, "TNK", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4100), 1L, null, null, null, true, false, null, null, "Teneke" },
                    { 24L, "KOV", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4101), 1L, null, null, null, true, false, null, null, "Kova" },
                    { 25L, "DZ", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4102), 1L, null, null, null, true, false, null, null, "Düzine" },
                    { 26L, "DST", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4103), 1L, null, null, null, true, false, null, null, "Deste" },
                    { 27L, "OHM", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4104), 1L, null, null, null, true, false, null, null, "Ohm" },
                    { 28L, "KW", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4105), 1L, null, null, null, true, false, null, null, "Kilowatt" },
                    { 29L, "W", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4106), 1L, null, null, null, true, false, null, null, "Watt" },
                    { 30L, "SN", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4107), 1L, null, null, null, true, false, null, null, "Saniye" },
                    { 31L, "DK", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4108), 1L, null, null, null, true, false, null, null, "Dakika" },
                    { 32L, "SA", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4109), 1L, null, null, null, true, false, null, null, "Saat" },
                    { 33L, "GUN", new DateTime(2026, 7, 7, 14, 24, 20, 512, DateTimeKind.Local).AddTicks(4110), 1L, null, null, null, true, false, null, null, "Gün" }
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
                name: "IX_Boyas_Code",
                table: "Boyas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boyas_CreatedDate",
                table: "Boyas",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Boyas_IsActive",
                table: "Boyas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Boyas_IsDeleted",
                table: "Boyas",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Boyas_SpecialCodeId",
                table: "Boyas",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emayes_Code",
                table: "Emayes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emayes_CreatedDate",
                table: "Emayes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Emayes_IsActive",
                table: "Emayes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Emayes_IsDeleted",
                table: "Emayes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Emayes_SpecialCodeId",
                table: "Emayes",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CreatedDate",
                table: "ExchangeRates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_IsDeleted",
                table: "ExchangeRates",
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
                name: "IX_QualityStandards_Code",
                table: "QualityStandards",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_CreatedDate",
                table: "QualityStandards",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_IsActive",
                table: "QualityStandards",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandards_IsDeleted",
                table: "QualityStandards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Screws_Code",
                table: "Screws",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screws_CreatedDate",
                table: "Screws",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Screws_IsActive",
                table: "Screws",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Screws_IsDeleted",
                table: "Screws",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Screws_SpecialCodeId",
                table: "Screws",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_Code",
                table: "SheetMetals",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_CreatedDate",
                table: "SheetMetals",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_GroupCodeId",
                table: "SheetMetals",
                column: "GroupCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_IsActive",
                table: "SheetMetals",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_IsDeleted",
                table: "SheetMetals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_QualityStandardId",
                table: "SheetMetals",
                column: "QualityStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_SpecialCodeId",
                table: "SheetMetals",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_SurfaceTypeId",
                table: "SheetMetals",
                column: "SurfaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetMetals_UnitId",
                table: "SheetMetals",
                column: "UnitId");

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
                name: "IX_SurfaceTypes_Code",
                table: "SurfaceTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurfaceTypes_CreatedDate",
                table: "SurfaceTypes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SurfaceTypes_IsActive",
                table: "SurfaceTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SurfaceTypes_IsDeleted",
                table: "SurfaceTypes",
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
                name: "Boyas");

            migrationBuilder.DropTable(
                name: "Emayes");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "ItemBarcodes");

            migrationBuilder.DropTable(
                name: "Screws");

            migrationBuilder.DropTable(
                name: "SheetMetals");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "QualityStandards");

            migrationBuilder.DropTable(
                name: "SpecialCode");

            migrationBuilder.DropTable(
                name: "SurfaceTypes");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
