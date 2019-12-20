using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InstallationCheckingBase.Migrations
{
    public partial class AddingMeterVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider
            var autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.DropForeignKey(
                name: "FK_Meter_Installations_InstallationId",
                table: "Meter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meter",
                table: "Meter");

            migrationBuilder.RenameTable(
                name: "Meter",
                newName: "Meters");

            migrationBuilder.DropIndex(
                name: "IX_Meter_InstallationId",
                table: "Meters");
            
            migrationBuilder.CreateIndex(
                "IX_Meters_InstallationId", 
                "Meters", 
                "InstallationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Meters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Meters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Meters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Meters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Meters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkflowState",
                table: "Meters",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meters",
                table: "Meters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MeterVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false),
                    QR = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    InstallationId = table.Column<int>(nullable: false),
                    MeterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterVersions_Installations_InstallationId",
                        column: x => x.InstallationId,
                        principalTable: "Installations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterVersions_InstallationId",
                table: "MeterVersions",
                column: "InstallationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meters_Installations_InstallationId",
                table: "Meters",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meters_Installations_InstallationId",
                table: "Meters");

            migrationBuilder.DropTable(
                name: "MeterVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meters",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "WorkflowState",
                table: "Meters");

            migrationBuilder.RenameTable(
                name: "Meters",
                newName: "Meter");

            migrationBuilder.DropIndex(
                name: "IX_Meters_InstallationId",
                table: "Meters");
            
            migrationBuilder.CreateIndex(
                "IX_Meter_InstallationId", 
                "Meter", 
                "InstallationId");
            
            migrationBuilder.AddPrimaryKey(
                name: "PK_Meter",
                table: "Meter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_Installations_InstallationId",
                table: "Meter",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
