using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCORE_RolePermissions");

            migrationBuilder.DropTable(
                name: "TCORE_Roles");
        }
    }
}
