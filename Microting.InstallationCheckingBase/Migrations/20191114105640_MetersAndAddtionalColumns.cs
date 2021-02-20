using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InstallationCheckingBase.Migrations
{
    public partial class MetersAndAddtionalColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider
            var autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralNumber",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralType",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivingFloorsNumber",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyNumber",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovalFormId",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearBuilt",
                table: "InstallationVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralNumber",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralType",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivingFloorsNumber",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyNumber",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovalFormId",
                table: "Installations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearBuilt",
                table: "Installations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    Num = table.Column<int>(nullable: false),
                    QR = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    InstallationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meter_Installations_InstallationId",
                        column: x => x.InstallationId,
                        principalTable: "Installations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meter_InstallationId",
                table: "Meter",
                column: "InstallationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CadastralNumber",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "CadastralType",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "LivingFloorsNumber",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "PropertyNumber",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "RemovalFormId",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "InstallationVersions");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CadastralNumber",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "CadastralType",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "LivingFloorsNumber",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "PropertyNumber",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "RemovalFormId",
                table: "Installations");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "Installations");
        }
    }
}
