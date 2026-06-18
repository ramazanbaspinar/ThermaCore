using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class KodSablonVeLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCORE_CodeTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CodePrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CodeSuffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StartNumber = table.Column<int>(type: "int", nullable: false),
                    NumericLength = table.Column<int>(type: "int", nullable: false),
                    DateFormat = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_TCORE_CodeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_KodLoglar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Modul = table.Column<int>(type: "int", nullable: false),
                    FirmaKodu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TarihKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SonKodDegeri = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_KodLoglar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_KodSablonlar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Modul = table.Column<int>(type: "int", nullable: false),
                    KodOnEk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SayisalUzunluk = table.Column<byte>(type: "tinyint", nullable: false),
                    BaslangicSayisi = table.Column<int>(type: "int", nullable: false),
                    TarihFormati = table.Column<int>(type: "int", nullable: false),
                    KodSonEk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OtomatikKodUretmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciMudahalesiDurumu = table.Column<bool>(type: "bit", nullable: false),
                    FirmaKisaKodKullanimDurumu = table.Column<bool>(type: "bit", nullable: false),
                    TarihliKodUretmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    TarihBazliKodSifrlamaDurumu = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_TCORE_KodSablonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_TenantDatabases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DatabaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Server = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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
                    table.PrimaryKey("PK_TCORE_TenantDatabases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_Terminals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HardwareFingerprint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LicenseKey = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_TCORE_Terminals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_UserInterfaceTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ControlName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    XmlData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_UserInterfaceTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_UserSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComputerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_UserSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_ModulePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CanView = table.Column<byte>(type: "tinyint", nullable: false),
                    CanAdd = table.Column<byte>(type: "tinyint", nullable: false),
                    CanEdit = table.Column<byte>(type: "tinyint", nullable: false),
                    CanDelete = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_ModulePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TCORE_ModulePermissions_TCORE_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "TCORE_UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_TCORE_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TCORE_Users_TCORE_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "TCORE_UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_UserPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CanView = table.Column<byte>(type: "tinyint", nullable: false),
                    CanAdd = table.Column<byte>(type: "tinyint", nullable: false),
                    CanEdit = table.Column<byte>(type: "tinyint", nullable: false),
                    CanDelete = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TCORE_UserPermissions_TCORE_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TCORE_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_Code",
                table: "TCORE_CodeTemplates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_CreatedDate",
                table: "TCORE_CodeTemplates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_IsActive",
                table: "TCORE_CodeTemplates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_IsDeleted",
                table: "TCORE_CodeTemplates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_KodSablonlar_CreatedDate",
                table: "TCORE_KodSablonlar",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_KodSablonlar_IsDeleted",
                table: "TCORE_KodSablonlar",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_ModulePermissions_CreatedDate",
                table: "TCORE_ModulePermissions",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_ModulePermissions_UserRoleId",
                table: "TCORE_ModulePermissions",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_TenantDatabases_Code",
                table: "TCORE_TenantDatabases",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_TenantDatabases_CreatedDate",
                table: "TCORE_TenantDatabases",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_TenantDatabases_IsActive",
                table: "TCORE_TenantDatabases",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_TenantDatabases_IsDeleted",
                table: "TCORE_TenantDatabases",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Terminals_Code",
                table: "TCORE_Terminals",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Terminals_CreatedDate",
                table: "TCORE_Terminals",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Terminals_IsActive",
                table: "TCORE_Terminals",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Terminals_IsDeleted",
                table: "TCORE_Terminals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserInterfaceTemplates_Code",
                table: "TCORE_UserInterfaceTemplates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserInterfaceTemplates_CreatedDate",
                table: "TCORE_UserInterfaceTemplates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserInterfaceTemplates_IsActive",
                table: "TCORE_UserInterfaceTemplates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserPermissions_CreatedDate",
                table: "TCORE_UserPermissions",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserPermissions_UserId",
                table: "TCORE_UserPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserRoles_Code",
                table: "TCORE_UserRoles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserRoles_CreatedDate",
                table: "TCORE_UserRoles",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserRoles_IsActive",
                table: "TCORE_UserRoles",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Users_Code",
                table: "TCORE_Users",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Users_CreatedDate",
                table: "TCORE_Users",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Users_IsActive",
                table: "TCORE_Users",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Users_IsDeleted",
                table: "TCORE_Users",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Users_UserRoleId",
                table: "TCORE_Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_UserSessions_CreatedDate",
                table: "TCORE_UserSessions",
                column: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCORE_CodeTemplates");

            migrationBuilder.DropTable(
                name: "TCORE_KodLoglar");

            migrationBuilder.DropTable(
                name: "TCORE_KodSablonlar");

            migrationBuilder.DropTable(
                name: "TCORE_ModulePermissions");

            migrationBuilder.DropTable(
                name: "TCORE_TenantDatabases");

            migrationBuilder.DropTable(
                name: "TCORE_Terminals");

            migrationBuilder.DropTable(
                name: "TCORE_UserInterfaceTemplates");

            migrationBuilder.DropTable(
                name: "TCORE_UserPermissions");

            migrationBuilder.DropTable(
                name: "TCORE_UserSessions");

            migrationBuilder.DropTable(
                name: "TCORE_Users");

            migrationBuilder.DropTable(
                name: "TCORE_UserRoles");
        }
    }
}
