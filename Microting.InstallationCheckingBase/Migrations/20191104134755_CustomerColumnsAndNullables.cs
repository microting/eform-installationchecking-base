using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InstallationCheckingBase.Migrations
{
    public partial class CustomerColumnsAndNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "InstallationVersions",
                newName: "InstallationId");

            migrationBuilder.AlterColumn<int>(
                name: "SdkCaseId",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRemove",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInstall",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActRemove",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "InstallationVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress2",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SdkCaseId",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRemove",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInstall",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActRemove",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Installations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress2",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Installations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstallationVersions_InstallationId",
                table: "InstallationVersions",
                column: "InstallationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallationVersions_Installations_InstallationId",
                table: "InstallationVersions",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallationVersions_Installations_InstallationId",
                table: "InstallationVersions");

            migrationBuilder.DropIndex(
                name: "IX_InstallationVersions_InstallationId",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CompanyAddress2",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CompanyAddress2",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Installations");

            migrationBuilder.RenameColumn(
                name: "InstallationId",
                table: "InstallationVersions",
                newName: "TaskId");

            migrationBuilder.AlterColumn<int>(
                name: "SdkCaseId",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRemove",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInstall",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActRemove",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "InstallationVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SdkCaseId",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRemove",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInstall",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateActRemove",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Installations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
