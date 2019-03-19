using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecianBP.Migrations
{
    public partial class Entities_cleared_empty_series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Symmetrical_Components");

            migrationBuilder.DropColumn(
                name: "U_avg_U4_C",
                table: "Voltages");

            migrationBuilder.DropColumn(
                name: "PF_PF4_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_3Pminus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P1minus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P2minus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P3minus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P4_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P4minus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "P_avg_P4plus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Q_avg_Q3_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Q_avg_Q4_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Q_avg_Q4minus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Q_avg_Q4plus_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "S_avg_S4_C",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Cos_Cos4_C",
                table: "Frequency");

            migrationBuilder.DropColumn(
                name: "D_avg_D4_C",
                table: "Frequency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "U_avg_U4_C",
                table: "Voltages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PF_PF4_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_3Pminus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P1minus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P2minus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P3minus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P4_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P4minus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "P_avg_P4plus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Q_avg_Q3_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Q_avg_Q4_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Q_avg_Q4minus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Q_avg_Q4plus_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "S_avg_S4_C",
                table: "Power",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cos_Cos4_C",
                table: "Frequency",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "D_avg_D4_C",
                table: "Frequency",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Symmetrical_Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    Symmetrical_Components_Negative_I2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_U2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_φI2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_φU2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_I1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_U1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_φI1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_φU1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Unba_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_I0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_U0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_φI0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_φU0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_i0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_i2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_u0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_u2_C = table.Column<float>(nullable: false),
                    TimeLocal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symmetrical_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symmetrical_Components_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symmetrical_Components_MeasurementPlaceId",
                table: "Symmetrical_Components",
                column: "MeasurementPlaceId");
        }
    }
}
