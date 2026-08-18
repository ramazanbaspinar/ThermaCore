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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                name: "CostParameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MaturityDifferenceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WastageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UseMaturityDifference = table.Column<bool>(type: "bit", nullable: false),
                    UseWasteRate = table.Column<bool>(type: "bit", nullable: false),
                    OvenAvgMonthlyProduction = table.Column<int>(type: "int", nullable: false),
                    CookerAvgMonthlyProduction = table.Column<int>(type: "int", nullable: false),
                    BuiltInAvgMonthlyProduction = table.Column<int>(type: "int", nullable: false),
                    FreestandingAvgMonthlyProduction = table.Column<int>(type: "int", nullable: false),
                    OtherAvgMonthlyProduction = table.Column<int>(type: "int", nullable: false),
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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    UpdatePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
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
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogicalRef = table.Column<long>(type: "bigint", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SpeCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Addr1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CCurrency = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    TownId = table.Column<long>(type: "bigint", nullable: true),
                    TelNrs1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TelNrs2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TaxNr = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentRef = table.Column<long>(type: "bigint", nullable: false),
                    EmailAddr = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebAddr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsEInvoiceUser = table.Column<bool>(type: "bit", nullable: false),
                    IsEDispatchUser = table.Column<bool>(type: "bit", nullable: false),
                    MailboxAlias = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaturityDays = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChemicalAndInsulationGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_ChemicalAndInsulationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChemicalAndInsulationGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChemicalAndInsulationGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalElectronicGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_ElectricalElectronicGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricalElectronicGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectricalElectronicGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinishedGoods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GroupType = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesVatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_FinishedGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinishedGoods_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FinishedGoods_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GasAndIgnitionGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_GasAndIgnitionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasAndIgnitionGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasAndIgnitionGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MechanicalAndHardwareGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_MechanicalAndHardwareGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicalAndHardwareGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MechanicalAndHardwareGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetalSheetGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    SurfaceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QualityCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SurfaceCoatingType = table.Column<int>(type: "int", nullable: false),
                    Density = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
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
                name: "OtherMaterialGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_OtherMaterialGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherMaterialGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OtherMaterialGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagingAndPrintingGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_PackagingAndPrintingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlasticAndVisualPartsGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_PlasticAndVisualPartsGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlasticAndVisualPartsGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlasticAndVisualPartsGroups_Units_BaseUnitId",
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

            migrationBuilder.CreateTable(
                name: "WireAndGridGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CoatingType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseUnitId = table.Column<long>(type: "bigint", nullable: true),
                    SpecialCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_WireAndGridGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WireAndGridGroups_SpecialCode_SpecialCodeId",
                        column: x => x.SpecialCodeId,
                        principalTable: "SpecialCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WireAndGridGroups_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRecipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FinishedGoodId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisionNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NetMaterialCost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
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
                    table.PrimaryKey("PK_ProductRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRecipes_FinishedGoods_FinishedGoodId",
                        column: x => x.FinishedGoodId,
                        principalTable: "FinishedGoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRecipeLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductRecipeId = table.Column<long>(type: "bigint", nullable: false),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    MaterialType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    WasteRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    WeightKg = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    SurfaceCoatingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoatingAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMaterialCost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CoatingMaterialId = table.Column<long>(type: "bigint", nullable: true),
                    ManualCoatingCost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProductRecipeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRecipeLines_ProductRecipes_ProductRecipeId",
                        column: x => x.ProductRecipeId,
                        principalTable: "ProductRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRecipeLines_Units_UnitId",
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
                    { 1L, "AD", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3057), 1L, null, null, null, true, false, null, null, "Adet" },
                    { 2L, "KG", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3074), 1L, null, null, null, true, false, null, null, "Kilogram" },
                    { 3L, "GR", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3076), 1L, null, null, null, true, false, null, null, "Gram" },
                    { 4L, "LT", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3079), 1L, null, null, null, true, false, null, null, "Litre" },
                    { 5L, "MT", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3080), 1L, null, null, null, true, false, null, null, "Metre" },
                    { 6L, "CM", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3082), 1L, null, null, null, true, false, null, null, "Santimetre" },
                    { 7L, "MM", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3083), 1L, null, null, null, true, false, null, null, "Milimetre" },
                    { 8L, "PK", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3094), 1L, null, null, null, true, false, null, null, "Paket" },
                    { 9L, "KL", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3095), 1L, null, null, null, true, false, null, null, "Koli" },
                    { 10L, "TON", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3077), 1L, null, null, null, true, false, null, null, "Ton" },
                    { 11L, "TK", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3097), 1L, null, null, null, true, false, null, null, "Takım" },
                    { 12L, "CU", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3100), 1L, null, null, null, true, false, null, null, "Çuval" },
                    { 13L, "KM", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3084), 1L, null, null, null, true, false, null, null, "Kilometre" },
                    { 14L, "M2", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3085), 1L, null, null, null, true, false, null, null, "Metrekare" },
                    { 15L, "CM2", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3086), 1L, null, null, null, true, false, null, null, "Santimetrekare" },
                    { 16L, "M3", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3088), 1L, null, null, null, true, false, null, null, "Metreküp" },
                    { 17L, "MIC", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3090), 1L, null, null, null, true, false, null, null, "Mikron" },
                    { 18L, "GR/M2", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3091), 1L, null, null, null, true, false, null, null, "Gram/Metrekare" },
                    { 19L, "KG/M2", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3092), 1L, null, null, null, true, false, null, null, "Kilogram/Metrekare" },
                    { 20L, "KUT", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3096), 1L, null, null, null, true, false, null, null, "Kutu" },
                    { 21L, "TBK", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3099), 1L, null, null, null, true, false, null, null, "Tabaka" },
                    { 22L, "BDN", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3101), 1L, null, null, null, true, false, null, null, "Bidon" },
                    { 23L, "TNK", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3102), 1L, null, null, null, true, false, null, null, "Teneke" },
                    { 24L, "KOV", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3103), 1L, null, null, null, true, false, null, null, "Kova" },
                    { 25L, "DZ", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3105), 1L, null, null, null, true, false, null, null, "Düzine" },
                    { 26L, "DST", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3106), 1L, null, null, null, true, false, null, null, "Deste" },
                    { 27L, "OHM", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3107), 1L, null, null, null, true, false, null, null, "Ohm" },
                    { 28L, "KW", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3108), 1L, null, null, null, true, false, null, null, "Kilowatt" },
                    { 29L, "W", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3109), 1L, null, null, null, true, false, null, null, "Watt" },
                    { 30L, "SN", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3110), 1L, null, null, null, true, false, null, null, "Saniye" },
                    { 31L, "DK", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3112), 1L, null, null, null, true, false, null, null, "Dakika" },
                    { 32L, "SA", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3113), 1L, null, null, null, true, false, null, null, "Saat" },
                    { 33L, "GUN", new DateTime(2026, 8, 18, 16, 3, 59, 515, DateTimeKind.Local).AddTicks(3114), 1L, null, null, null, true, false, null, null, "Gün" }
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
                name: "IX_ChemicalAndInsulationGroups_BaseUnitId",
                table: "ChemicalAndInsulationGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_Code",
                table: "ChemicalAndInsulationGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_Code_BranchId_IsDeleted",
                table: "ChemicalAndInsulationGroups",
                columns: new[] { "Code", "BranchId", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_CreatedDate",
                table: "ChemicalAndInsulationGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_IsActive",
                table: "ChemicalAndInsulationGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_IsDeleted",
                table: "ChemicalAndInsulationGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_SpecialCodeId",
                table: "ChemicalAndInsulationGroups",
                column: "SpecialCodeId");

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
                name: "IX_Cities_LogicalRef",
                table: "Cities",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_CostParameters_CreatedDate",
                table: "CostParameters",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_CostParameters_IsDeleted",
                table: "CostParameters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

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
                name: "IX_Countries_LogicalRef",
                table: "Countries",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CardType",
                table: "CurrentAccounts",
                column: "CardType");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CityId",
                table: "CurrentAccounts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CountryId",
                table: "CurrentAccounts",
                column: "CountryId");

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
                name: "IX_CurrentAccounts_LogicalRef",
                table: "CurrentAccounts",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_TownId",
                table: "CurrentAccounts",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_BaseUnitId",
                table: "ElectricalElectronicGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_BranchId",
                table: "ElectricalElectronicGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_Code",
                table: "ElectricalElectronicGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_CreatedDate",
                table: "ElectricalElectronicGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_IsActive",
                table: "ElectricalElectronicGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_IsDeleted",
                table: "ElectricalElectronicGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_SpecialCodeId",
                table: "ElectricalElectronicGroups",
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
                name: "IX_FinishedGoods_Code",
                table: "FinishedGoods",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_CreatedDate",
                table: "FinishedGoods",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_GroupType",
                table: "FinishedGoods",
                column: "GroupType");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_IsActive",
                table: "FinishedGoods",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_IsDeleted",
                table: "FinishedGoods",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_SpecialCodeId",
                table: "FinishedGoods",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_UnitId",
                table: "FinishedGoods",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_BaseUnitId",
                table: "GasAndIgnitionGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_BranchId",
                table: "GasAndIgnitionGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_CreatedDate",
                table: "GasAndIgnitionGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_IsActive",
                table: "GasAndIgnitionGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_IsDeleted",
                table: "GasAndIgnitionGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_SpecialCodeId",
                table: "GasAndIgnitionGroups",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses",
                column: "Code",
                unique: true);

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
                name: "IX_MechanicalAndHardwareGroups_BaseUnitId",
                table: "MechanicalAndHardwareGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_Code",
                table: "MechanicalAndHardwareGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_CreatedDate",
                table: "MechanicalAndHardwareGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_IsActive",
                table: "MechanicalAndHardwareGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_IsDeleted",
                table: "MechanicalAndHardwareGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_SpecialCodeId",
                table: "MechanicalAndHardwareGroups",
                column: "SpecialCodeId");

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
                column: "Code",
                unique: true);

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
                name: "IX_OtherMaterialGroups_BaseUnitId",
                table: "OtherMaterialGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_Code",
                table: "OtherMaterialGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_CreatedDate",
                table: "OtherMaterialGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_IsActive",
                table: "OtherMaterialGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_IsDeleted",
                table: "OtherMaterialGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_SpecialCodeId",
                table: "OtherMaterialGroups",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_BaseUnitId",
                table: "PackagingAndPrintingGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_Code",
                table: "PackagingAndPrintingGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_Code_BranchId_IsDeleted",
                table: "PackagingAndPrintingGroups",
                columns: new[] { "Code", "BranchId", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_CreatedDate",
                table: "PackagingAndPrintingGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_IsActive",
                table: "PackagingAndPrintingGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_IsDeleted",
                table: "PackagingAndPrintingGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_SpecialCodeId",
                table: "PackagingAndPrintingGroups",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_BaseUnitId",
                table: "PlasticAndVisualPartsGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_BranchId",
                table: "PlasticAndVisualPartsGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_CreatedDate",
                table: "PlasticAndVisualPartsGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_IsActive",
                table: "PlasticAndVisualPartsGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_IsDeleted",
                table: "PlasticAndVisualPartsGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_SpecialCodeId",
                table: "PlasticAndVisualPartsGroups",
                column: "SpecialCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipeLines_CreatedDate",
                table: "ProductRecipeLines",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipeLines_IsDeleted",
                table: "ProductRecipeLines",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipeLines_ProductRecipeId",
                table: "ProductRecipeLines",
                column: "ProductRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipeLines_UnitId",
                table: "ProductRecipeLines",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_Code",
                table: "ProductRecipes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_Code_RevisionNumber",
                table: "ProductRecipes",
                columns: new[] { "Code", "RevisionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_CreatedDate",
                table: "ProductRecipes",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_FinishedGoodId",
                table: "ProductRecipes",
                column: "FinishedGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_IsActive",
                table: "ProductRecipes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipes_IsDeleted",
                table: "ProductRecipes",
                column: "IsDeleted");

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

            migrationBuilder.CreateIndex(
                name: "IX_Towns_LogicalRef",
                table: "Towns",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

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

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Code",
                table: "Warehouses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CreatedDate",
                table: "Warehouses",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_IsActive",
                table: "Warehouses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_IsDeleted",
                table: "Warehouses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_BaseUnitId",
                table: "WireAndGridGroups",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_Code",
                table: "WireAndGridGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_CreatedDate",
                table: "WireAndGridGroups",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_IsActive",
                table: "WireAndGridGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_IsDeleted",
                table: "WireAndGridGroups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_SpecialCodeId",
                table: "WireAndGridGroups",
                column: "SpecialCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDocuments");

            migrationBuilder.DropTable(
                name: "ChemicalAndInsulationGroups");

            migrationBuilder.DropTable(
                name: "CostParameters");

            migrationBuilder.DropTable(
                name: "CurrentAccounts");

            migrationBuilder.DropTable(
                name: "ElectricalElectronicGroups");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "GasAndIgnitionGroups");

            migrationBuilder.DropTable(
                name: "GeneralExpenses");

            migrationBuilder.DropTable(
                name: "ItemBarcodes");

            migrationBuilder.DropTable(
                name: "MaterialCost");

            migrationBuilder.DropTable(
                name: "MechanicalAndHardwareGroups");

            migrationBuilder.DropTable(
                name: "MetalSheetGroups");

            migrationBuilder.DropTable(
                name: "OtherMaterialGroups");

            migrationBuilder.DropTable(
                name: "PackagingAndPrintingGroups");

            migrationBuilder.DropTable(
                name: "PlasticAndVisualPartsGroups");

            migrationBuilder.DropTable(
                name: "ProductRecipeLines");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "UnitConversions");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "WireAndGridGroups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "ProductRecipes");

            migrationBuilder.DropTable(
                name: "FinishedGoods");

            migrationBuilder.DropTable(
                name: "SpecialCode");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
