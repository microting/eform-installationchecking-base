using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InstallationCheckingBase.Migrations
{
    public partial class AddingInstallationImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstallationImageName",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstallationImageName",
                table: "Installations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallationImageName",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "InstallationImageName",
                table: "Installations");
        }
    }
}
