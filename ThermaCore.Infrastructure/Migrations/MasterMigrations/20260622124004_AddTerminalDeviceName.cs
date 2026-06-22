using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Migrations.MasterMigrations
{
    /// <inheritdoc />
    public partial class AddTerminalDeviceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Terminals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Terminals");
        }
    }
}
