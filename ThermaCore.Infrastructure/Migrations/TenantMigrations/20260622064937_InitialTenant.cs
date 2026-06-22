using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Migrations.TenantMigrations
{
    /// <inheritdoc />
    public partial class InitialTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCORE_CodeLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastCodeValue = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_CodeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCORE_CodeTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CodePrefix = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumericLength = table.Column<byte>(type: "tinyint", nullable: false),
                    StartNumber = table.Column<int>(type: "int", nullable: false),
                    DateFormat = table.Column<int>(type: "int", nullable: false),
                    CodeSuffix = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAutoCodeGenerationEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsUserInterventionAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsCompanyShortCodeUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsDateBasedCodeGenerationEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDateBasedCodeResetEnabled = table.Column<bool>(type: "bit", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "TCORE_Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_TCORE_Roles", x => x.Id);
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
                name: "TCORE_RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    SpecialPermissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TCORE_RolePermissions_TCORE_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TCORE_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_CreatedDate",
                table: "TCORE_CodeTemplates",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_IsDeleted",
                table: "TCORE_CodeTemplates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_ModulePermissions_CreatedDate",
                table: "TCORE_ModulePermissions",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_RolePermissions_RoleId",
                table: "TCORE_RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Roles_Code",
                table: "TCORE_Roles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Roles_CreatedDate",
                table: "TCORE_Roles",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Roles_IsActive",
                table: "TCORE_Roles",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_Roles_IsDeleted",
                table: "TCORE_Roles",
                column: "IsDeleted");

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
                name: "IX_TCORE_UserSessions_CreatedDate",
                table: "TCORE_UserSessions",
                column: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCORE_CodeLogs");

            migrationBuilder.DropTable(
                name: "TCORE_CodeTemplates");

            migrationBuilder.DropTable(
                name: "TCORE_ModulePermissions");

            migrationBuilder.DropTable(
                name: "TCORE_RolePermissions");

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
                name: "TCORE_Roles");
        }
    }
}
