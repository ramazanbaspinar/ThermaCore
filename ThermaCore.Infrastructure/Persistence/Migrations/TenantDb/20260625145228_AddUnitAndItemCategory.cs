using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThermaCore.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddUnitAndItemCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategories_ItemCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Description", "IsActive", "IsDeleted", "ModifiedDate", "ModifiedUserId", "Name" },
                values: new object[,]
                {
                    { 1L, "AD", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3114), 1L, null, null, null, true, false, null, null, "Adet" },
                    { 2L, "KG", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3129), 1L, null, null, null, true, false, null, null, "Kilogram" },
                    { 3L, "GR", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3130), 1L, null, null, null, true, false, null, null, "Gram" },
                    { 4L, "LT", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3131), 1L, null, null, null, true, false, null, null, "Litre" },
                    { 5L, "MT", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3132), 1L, null, null, null, true, false, null, null, "Metre" },
                    { 6L, "CM", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3133), 1L, null, null, null, true, false, null, null, "Santimetre" },
                    { 7L, "MM", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3134), 1L, null, null, null, true, false, null, null, "Milimetre" },
                    { 8L, "PK", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3135), 1L, null, null, null, true, false, null, null, "Paket" },
                    { 9L, "KL", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3136), 1L, null, null, null, true, false, null, null, "Koli" },
                    { 10L, "TON", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3137), 1L, null, null, null, true, false, null, null, "Ton" },
                    { 11L, "TK", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3138), 1L, null, null, null, true, false, null, null, "Takım" },
                    { 12L, "CU", new DateTime(2026, 6, 25, 17, 52, 27, 580, DateTimeKind.Local).AddTicks(3139), 1L, null, null, null, true, false, null, null, "Çuval" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_Code",
                table: "ItemCategories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CreatedDate",
                table: "ItemCategories",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_IsActive",
                table: "ItemCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_IsDeleted",
                table: "ItemCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_ParentId",
                table: "ItemCategories",
                column: "ParentId");

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
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
