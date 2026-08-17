using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinBeyazEsya.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddEnterpriseIndexesAndConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups");

            migrationBuilder.DropIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalAndHardwareGroups_Code",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses");

            migrationBuilder.DropIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups");

            migrationBuilder.DropIndex(
                name: "IX_FinishedGoods_Code",
                table: "FinishedGoods");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalElectronicGroups_Code",
                table: "ElectricalElectronicGroups");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Code",
                table: "Countries");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 23, 40, 0, 533, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.CreateIndex(
                name: "IX_Towns_LogicalRef",
                table: "Towns",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_Code",
                table: "MechanicalAndHardwareGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_Code",
                table: "FinishedGoods",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_GroupType",
                table: "FinishedGoods",
                column: "GroupType");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_Code",
                table: "ElectricalElectronicGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CardType",
                table: "CurrentAccounts",
                column: "CardType");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_LogicalRef",
                table: "CurrentAccounts",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LogicalRef",
                table: "Countries",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LogicalRef",
                table: "Cities",
                column: "LogicalRef",
                unique: true,
                filter: "[LogicalRef] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Towns_LogicalRef",
                table: "Towns");

            migrationBuilder.DropIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups");

            migrationBuilder.DropIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalAndHardwareGroups_Code",
                table: "MechanicalAndHardwareGroups");

            migrationBuilder.DropIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses");

            migrationBuilder.DropIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups");

            migrationBuilder.DropIndex(
                name: "IX_FinishedGoods_Code",
                table: "FinishedGoods");

            migrationBuilder.DropIndex(
                name: "IX_FinishedGoods_GroupType",
                table: "FinishedGoods");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalElectronicGroups_Code",
                table: "ElectricalElectronicGroups");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_CardType",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_LogicalRef",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Code",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_LogicalRef",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_LogicalRef",
                table: "Cities");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 17, 22, 20, 1, 53, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.CreateIndex(
                name: "IX_PlasticAndVisualPartsGroups_Code",
                table: "PlasticAndVisualPartsGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MetalSheetGroups_Code",
                table: "MetalSheetGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalAndHardwareGroups_Code",
                table: "MechanicalAndHardwareGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_Code",
                table: "GeneralExpenses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GasAndIgnitionGroups_Code",
                table: "GasAndIgnitionGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedGoods_Code",
                table: "FinishedGoods",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalElectronicGroups_Code",
                table: "ElectricalElectronicGroups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_Code",
                table: "CurrentAccounts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code");
        }
    }
}
