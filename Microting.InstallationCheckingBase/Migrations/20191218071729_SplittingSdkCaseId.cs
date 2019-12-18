using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InstallationCheckingBase.Migrations
{
    public partial class SplittingSdkCaseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SdkCaseId",
                table: "InstallationVersions",
                newName: "RemovalSdkCaseId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "InstallationVersions",
                newName: "RemovalEmployeeId");

            migrationBuilder.RenameColumn(
                name: "SdkCaseId",
                table: "Installations",
                newName: "RemovalSdkCaseId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Installations",
                newName: "RemovalEmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "InstallationEmployeeId",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallationSdkCaseId",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallationEmployeeId",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallationSdkCaseId",
                table: "Installations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallationEmployeeId",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "InstallationSdkCaseId",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "InstallationEmployeeId",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "InstallationSdkCaseId",
                table: "Installations");

            migrationBuilder.RenameColumn(
                name: "RemovalSdkCaseId",
                table: "InstallationVersions",
                newName: "SdkCaseId");

            migrationBuilder.RenameColumn(
                name: "RemovalEmployeeId",
                table: "InstallationVersions",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "RemovalSdkCaseId",
                table: "Installations",
                newName: "SdkCaseId");

            migrationBuilder.RenameColumn(
                name: "RemovalEmployeeId",
                table: "Installations",
                newName: "EmployeeId");
        }
    }
}
