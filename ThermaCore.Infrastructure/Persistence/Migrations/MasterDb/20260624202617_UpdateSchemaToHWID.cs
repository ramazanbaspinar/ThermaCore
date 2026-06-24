using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.MasterDb
{
    /// <inheritdoc />
    public partial class UpdateSchemaToHWID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EthernetMacAddress",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "VpnMacAddress",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "WifiMacAddress",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "ServerCpuId",
                table: "SystemLicenses");

            migrationBuilder.RenameColumn(
                name: "DeviceName",
                table: "Terminals",
                newName: "HardwareId");

            migrationBuilder.RenameColumn(
                name: "ServerMacAddress",
                table: "SystemLicenses",
                newName: "ServerHardwareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HardwareId",
                table: "Terminals",
                newName: "DeviceName");

            migrationBuilder.RenameColumn(
                name: "ServerHardwareId",
                table: "SystemLicenses",
                newName: "ServerMacAddress");

            migrationBuilder.AddColumn<string>(
                name: "EthernetMacAddress",
                table: "Terminals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
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

            migrationBuilder.AddColumn<string>(
                name: "WifiMacAddress",
                table: "Terminals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServerCpuId",
                table: "SystemLicenses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
