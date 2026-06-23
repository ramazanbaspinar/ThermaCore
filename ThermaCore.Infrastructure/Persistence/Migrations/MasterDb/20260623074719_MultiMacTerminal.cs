using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.MasterDb
{
    /// <inheritdoc />
    public partial class MultiMacTerminal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MacAddress",
                table: "Terminals",
                newName: "WifiMacAddress");

            migrationBuilder.AddColumn<string>(
                name: "EthernetMacAddress",
                table: "Terminals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VpnMacAddress",
                table: "Terminals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EthernetMacAddress",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "VpnMacAddress",
                table: "Terminals");

            migrationBuilder.RenameColumn(
                name: "WifiMacAddress",
                table: "Terminals",
                newName: "MacAddress");
        }
    }
}
