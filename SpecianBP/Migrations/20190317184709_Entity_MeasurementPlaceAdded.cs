using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecianBP.Migrations
{
    public partial class Entity_MeasurementPlaceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Voltages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Temperature",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Symmetrical_Components",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Status",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Power",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Frequency",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Current",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementPlaceId",
                table: "Comm",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MeasurementPlace",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPlace", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voltages_MeasurementPlaceId",
                table: "Voltages",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MeasurementPlaceId",
                table: "Temperature",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Symmetrical_Components_MeasurementPlaceId",
                table: "Symmetrical_Components",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_MeasurementPlaceId",
                table: "Status",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Power_MeasurementPlaceId",
                table: "Power",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequency_MeasurementPlaceId",
                table: "Frequency",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Current_MeasurementPlaceId",
                table: "Current",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_MeasurementPlaceId",
                table: "Comm",
                column: "MeasurementPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comm_MeasurementPlace_MeasurementPlaceId",
                table: "Comm",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Current_MeasurementPlace_MeasurementPlaceId",
                table: "Current",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequency_MeasurementPlace_MeasurementPlaceId",
                table: "Frequency",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Power_MeasurementPlace_MeasurementPlaceId",
                table: "Power",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_MeasurementPlace_MeasurementPlaceId",
                table: "Status",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Symmetrical_Components_MeasurementPlace_MeasurementPlaceId",
                table: "Symmetrical_Components",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperature_MeasurementPlace_MeasurementPlaceId",
                table: "Temperature",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voltages_MeasurementPlace_MeasurementPlaceId",
                table: "Voltages",
                column: "MeasurementPlaceId",
                principalTable: "MeasurementPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comm_MeasurementPlace_MeasurementPlaceId",
                table: "Comm");

            migrationBuilder.DropForeignKey(
                name: "FK_Current_MeasurementPlace_MeasurementPlaceId",
                table: "Current");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequency_MeasurementPlace_MeasurementPlaceId",
                table: "Frequency");

            migrationBuilder.DropForeignKey(
                name: "FK_Power_MeasurementPlace_MeasurementPlaceId",
                table: "Power");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_MeasurementPlace_MeasurementPlaceId",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Symmetrical_Components_MeasurementPlace_MeasurementPlaceId",
                table: "Symmetrical_Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperature_MeasurementPlace_MeasurementPlaceId",
                table: "Temperature");

            migrationBuilder.DropForeignKey(
                name: "FK_Voltages_MeasurementPlace_MeasurementPlaceId",
                table: "Voltages");

            migrationBuilder.DropTable(
                name: "MeasurementPlace");

            migrationBuilder.DropIndex(
                name: "IX_Voltages_MeasurementPlaceId",
                table: "Voltages");

            migrationBuilder.DropIndex(
                name: "IX_Temperature_MeasurementPlaceId",
                table: "Temperature");

            migrationBuilder.DropIndex(
                name: "IX_Symmetrical_Components_MeasurementPlaceId",
                table: "Symmetrical_Components");

            migrationBuilder.DropIndex(
                name: "IX_Status_MeasurementPlaceId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Power_MeasurementPlaceId",
                table: "Power");

            migrationBuilder.DropIndex(
                name: "IX_Frequency_MeasurementPlaceId",
                table: "Frequency");

            migrationBuilder.DropIndex(
                name: "IX_Current_MeasurementPlaceId",
                table: "Current");

            migrationBuilder.DropIndex(
                name: "IX_Comm_MeasurementPlaceId",
                table: "Comm");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Voltages");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Temperature");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Symmetrical_Components");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Frequency");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Current");

            migrationBuilder.DropColumn(
                name: "MeasurementPlaceId",
                table: "Comm");
        }
    }
}
