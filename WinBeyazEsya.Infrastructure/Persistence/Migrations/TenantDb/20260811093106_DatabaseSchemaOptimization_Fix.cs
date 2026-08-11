using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class DatabaseSchemaOptimization_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalAndHardwareGroups_SpecialCode_SpecialCodeId",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalAndHardwareGroups_Units_BaseUnitId",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMaterialGroups_SpecialCode_SpecialCodeId",
                table: "OtherMaterialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMaterialGroups_Units_BaseUnitId",
                table: "OtherMaterialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_WireAndGridGroups_SpecialCode_SpecialCodeId",
                table: "WireAndGridGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_WireAndGridGroups_Units_BaseUnitId",
                table: "WireAndGridGroups");

            migrationBuilder.DropIndex(
                name: "IX_WireAndGridGroups_Code",
                table: "WireAndGridGroups");

            migrationBuilder.DropIndex(
                name: "IX_OtherMaterialGroups_Code",
                table: "OtherMaterialGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "WireAndGridGroups");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "PlasticAndVisualPartsGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WireAndGridGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialType",
                table: "WireAndGridGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WireAndGridGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CoatingType",
                table: "WireAndGridGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlasticAndVisualPartsGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PlasticAndVisualPartsGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OtherMaterialGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OtherMaterialGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MetalSheetGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MetalSheetGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GasAndIgnitionGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GasAndIgnitionGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectricalElectronicGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ElectricalElectronicGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_Code",
                table: "WireAndGridGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackagingAndPrintingGroups_Code_BranchId_IsDeleted",
                table: "PackagingAndPrintingGroups",
                columns: new[] { "Code", "BranchId", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_Code",
                table: "OtherMaterialGroups",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalAndHardwareGroups_SpecialCode_SpecialCodeId",
                table: "MechanicalAndHardwareGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalAndHardwareGroups_Units_BaseUnitId",
                table: "MechanicalAndHardwareGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMaterialGroups_SpecialCode_SpecialCodeId",
                table: "OtherMaterialGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMaterialGroups_Units_BaseUnitId",
                table: "OtherMaterialGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                table: "PackagingAndPrintingGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                table: "PackagingAndPrintingGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WireAndGridGroups_SpecialCode_SpecialCodeId",
                table: "WireAndGridGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WireAndGridGroups_Units_BaseUnitId",
                table: "WireAndGridGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalAndHardwareGroups_SpecialCode_SpecialCodeId",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalAndHardwareGroups_Units_BaseUnitId",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMaterialGroups_SpecialCode_SpecialCodeId",
                table: "OtherMaterialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMaterialGroups_Units_BaseUnitId",
                table: "OtherMaterialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_WireAndGridGroups_SpecialCode_SpecialCodeId",
                table: "WireAndGridGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_WireAndGridGroups_Units_BaseUnitId",
                table: "WireAndGridGroups");

            migrationBuilder.DropIndex(
                name: "IX_WireAndGridGroups_Code",
                table: "WireAndGridGroups");

            migrationBuilder.DropIndex(
                name: "IX_PackagingAndPrintingGroups_Code_BranchId_IsDeleted",
                table: "PackagingAndPrintingGroups");

            migrationBuilder.DropIndex(
                name: "IX_OtherMaterialGroups_Code",
                table: "OtherMaterialGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WireAndGridGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialType",
                table: "WireAndGridGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WireAndGridGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CoatingType",
                table: "WireAndGridGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "WireAndGridGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlasticAndVisualPartsGroups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PlasticAndVisualPartsGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "PlasticAndVisualPartsGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PackagingAndPrintingGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OtherMaterialGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OtherMaterialGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MetalSheetGroups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MetalSheetGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MechanicalAndHardwareGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GasAndIgnitionGroups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GasAndIgnitionGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectricalElectronicGroups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ElectricalElectronicGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 11, 12, 20, 21, 668, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.CreateIndex(
                name: "IX_WireAndGridGroups_Code",
                table: "WireAndGridGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialGroups_Code",
                table: "OtherMaterialGroups",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalAndHardwareGroups_SpecialCode_SpecialCodeId",
                table: "MechanicalAndHardwareGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalAndHardwareGroups_Units_BaseUnitId",
                table: "MechanicalAndHardwareGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMaterialGroups_SpecialCode_SpecialCodeId",
                table: "OtherMaterialGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMaterialGroups_Units_BaseUnitId",
                table: "OtherMaterialGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingAndPrintingGroups_SpecialCode_SpecialCodeId",
                table: "PackagingAndPrintingGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingAndPrintingGroups_Units_BaseUnitId",
                table: "PackagingAndPrintingGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WireAndGridGroups_SpecialCode_SpecialCodeId",
                table: "WireAndGridGroups",
                column: "SpecialCodeId",
                principalTable: "SpecialCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WireAndGridGroups_Units_BaseUnitId",
                table: "WireAndGridGroups",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
