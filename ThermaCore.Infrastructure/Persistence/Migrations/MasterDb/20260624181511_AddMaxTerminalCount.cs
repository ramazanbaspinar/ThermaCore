using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThermaCore.Infrastructure.Persistence.Migrations.MasterDb
{
    /// <inheritdoc />
    public partial class AddMaxTerminalCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxTerminalCount",
                table: "SystemLicenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTerminalCount",
                table: "SystemLicenses");
        }
    }
}
