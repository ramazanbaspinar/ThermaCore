using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameKodSablonAndKodLogToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCORE_KodLoglar");

            migrationBuilder.DropTable(
                name: "TCORE_KodSablonlar");

            migrationBuilder.DropIndex(
                name: "IX_TCORE_CodeTemplates_Code",
                table: "TCORE_CodeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_TCORE_CodeTemplates_IsActive",
                table: "TCORE_CodeTemplates");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TCORE_CodeTemplates");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TCORE_CodeTemplates",
                newName: "IsUserInterventionAllowed");

            migrationBuilder.AlterColumn<byte>(
                name: "NumericLength",
                table: "TCORE_CodeTemplates",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CodeSuffix",
                table: "TCORE_CodeTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CodePrefix",
                table: "TCORE_CodeTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "IsAutoCodeGenerationEnabled",
                table: "TCORE_CodeTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompanyShortCodeUsed",
                table: "TCORE_CodeTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDateBasedCodeGenerationEnabled",
                table: "TCORE_CodeTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDateBasedCodeResetEnabled",
                table: "TCORE_CodeTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCORE_CodeLogs");

            migrationBuilder.DropColumn(
                name: "IsAutoCodeGenerationEnabled",
                table: "TCORE_CodeTemplates");

            migrationBuilder.DropColumn(
                name: "IsCompanyShortCodeUsed",
                table: "TCORE_CodeTemplates");

            migrationBuilder.DropColumn(
                name: "IsDateBasedCodeGenerationEnabled",
                table: "TCORE_CodeTemplates");

            migrationBuilder.DropColumn(
                name: "IsDateBasedCodeResetEnabled",
                table: "TCORE_CodeTemplates");

            migrationBuilder.RenameColumn(
                name: "IsUserInterventionAllowed",
                table: "TCORE_CodeTemplates",
                newName: "IsActive");

            migrationBuilder.AlterColumn<int>(
                name: "NumericLength",
                table: "TCORE_CodeTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "CodeSuffix",
                table: "TCORE_CodeTemplates",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CodePrefix",
                table: "TCORE_CodeTemplates",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TCORE_CodeTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TCORE_KodLoglar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    FirmaKodu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modul = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SonKodDegeri = table.Column<int>(type: "int", nullable: false),
                    TarihKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    BaslangicSayisi = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true),
                    FirmaKisaKodKullanimDurumu = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    KodOnEk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KodSonEk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KullaniciMudahalesiDurumu = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Modul = table.Column<int>(type: "int", nullable: false),
                    OtomatikKodUretmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SayisalUzunluk = table.Column<byte>(type: "tinyint", nullable: false),
                    TarihBazliKodSifrlamaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    TarihFormati = table.Column<int>(type: "int", nullable: false),
                    TarihliKodUretmeDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCORE_KodSablonlar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_Code",
                table: "TCORE_CodeTemplates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_CodeTemplates_IsActive",
                table: "TCORE_CodeTemplates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_KodSablonlar_CreatedDate",
                table: "TCORE_KodSablonlar",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_TCORE_KodSablonlar_IsDeleted",
                table: "TCORE_KodSablonlar",
                column: "IsDeleted");
        }
    }
}
