using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class DatabaseSchemaOptimization_Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalAndInsulationGroups_SpecialCode_SpecialCodeId",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalAndInsulationGroups_Units_BaseUnitId",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "OtherMaterialGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2146));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 40, 38, 999, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAndInsulationGroups_Code_BranchId_IsDeleted",
                table: "ChemicalAndInsulationGroups",
                columns: new[] { "Code", "BranchId", "IsDeleted" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalAndInsulationGroups_SpecialCode_SpecialCodeId",
                table: "ChemicalAndInsulationGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalAndInsulationGroups_Units_BaseUnitId",
                table: "ChemicalAndInsulationGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalAndInsulationGroups_SpecialCode_SpecialCodeId",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalAndInsulationGroups_Units_BaseUnitId",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.DropIndex(
                name: "IX_ChemicalAndInsulationGroups_Code_BranchId_IsDeleted",
                table: "ChemicalAndInsulationGroups");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "PackagingAndPrintingGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "OtherMaterialGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "MechanicalAndHardwareGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ChemicalAndInsulationGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ChemicalAndInsulationGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 31, 6, 84, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalAndInsulationGroups_SpecialCode_SpecialCodeId",
                table: "ChemicalAndInsulationGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalAndInsulationGroups_Units_BaseUnitId",
                table: "ChemicalAndInsulationGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
