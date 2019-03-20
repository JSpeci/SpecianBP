using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecianBP.Migrations
{
    public partial class Entity_MeasurementPlaceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementPlace",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SeriesName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GrantsSerialized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    I_avg_IPEc_C = table.Column<float>(nullable: false),
                    I_avg_INc_C = table.Column<float>(nullable: false),
                    I_avg_I4_C = table.Column<float>(nullable: false),
                    I_avg_I3_C = table.Column<float>(nullable: false),
                    I_avg_I2_C = table.Column<float>(nullable: false),
                    I_avg_I1_C = table.Column<float>(nullable: false),
                    I_avg_3I_C = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Current_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    f_avg_f_C = table.Column<float>(nullable: false),
                    D_avg_D4_C = table.Column<float>(nullable: false),
                    D_avg_D3_C = table.Column<float>(nullable: false),
                    D_avg_D2_C = table.Column<float>(nullable: false),
                    D_avg_D1_C = table.Column<float>(nullable: false),
                    D_avg_3D_C = table.Column<float>(nullable: false),
                    Cos_Cos4_C = table.Column<float>(nullable: false),
                    Cos_Cos3_C = table.Column<float>(nullable: false),
                    Cos_Cos2_C = table.Column<float>(nullable: false),
                    Cos_Cos1_C = table.Column<float>(nullable: false),
                    Cos_3Cos_C = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frequency_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    S_avg_S4_C = table.Column<float>(nullable: false),
                    S_avg_S3_C = table.Column<float>(nullable: false),
                    S_avg_S2_C = table.Column<float>(nullable: false),
                    S_avg_S1_C = table.Column<float>(nullable: false),
                    S_avg_3S_C = table.Column<float>(nullable: false),
                    Q_avg_Q4plus_C = table.Column<float>(nullable: false),
                    Q_avg_Q4minus_C = table.Column<float>(nullable: false),
                    Q_avg_Q4_C = table.Column<float>(nullable: false),
                    Q_avg_Q3plus_C = table.Column<float>(nullable: false),
                    Q_avg_Q3minus_C = table.Column<float>(nullable: false),
                    Q_avg_Q3_C = table.Column<float>(nullable: false),
                    Q_avg_Q2plus_C = table.Column<float>(nullable: false),
                    Q_avg_Q2minus_C = table.Column<float>(nullable: false),
                    Q_avg_Q2_C = table.Column<float>(nullable: false),
                    Q_avg_Q1plus_C = table.Column<float>(nullable: false),
                    Q_avg_Q1minus_C = table.Column<float>(nullable: false),
                    Q_avg_Q1_C = table.Column<float>(nullable: false),
                    Q_avg_3Qplus_C = table.Column<float>(nullable: false),
                    Q_avg_3Qminus_C = table.Column<float>(nullable: false),
                    Q_avg_3Q_C = table.Column<float>(nullable: false),
                    PF_PF4_C = table.Column<float>(nullable: false),
                    PF_PF3_C = table.Column<float>(nullable: false),
                    PF_PF2_C = table.Column<float>(nullable: false),
                    PF_PF1_C = table.Column<float>(nullable: false),
                    PF_3PF_C = table.Column<float>(nullable: false),
                    P_avg_P4plus_C = table.Column<float>(nullable: false),
                    P_avg_P4minus_C = table.Column<float>(nullable: false),
                    P_avg_P4_C = table.Column<float>(nullable: false),
                    P_avg_P3plus_C = table.Column<float>(nullable: false),
                    P_avg_P3minus_C = table.Column<float>(nullable: false),
                    P_avg_P3_C = table.Column<float>(nullable: false),
                    P_avg_P2plus_C = table.Column<float>(nullable: false),
                    P_avg_P2minus_C = table.Column<float>(nullable: false),
                    P_avg_P2_C = table.Column<float>(nullable: false),
                    P_avg_P1plus_C = table.Column<float>(nullable: false),
                    P_avg_P1minus_C = table.Column<float>(nullable: false),
                    P_avg_P1_C = table.Column<float>(nullable: false),
                    P_avg_3Pplus_C = table.Column<float>(nullable: false),
                    P_avg_3Pminus_C = table.Column<float>(nullable: false),
                    P_avg_3P_C = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Power_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    Status_Flow_C = table.Column<string>(nullable: true),
                    Status_Flags_C = table.Column<string>(nullable: true),
                    Status_Flagging_UIP3_C = table.Column<bool>(nullable: false),
                    Status_Flagging_UIP2_C = table.Column<bool>(nullable: false),
                    Status_Flagging_UIP1_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Time_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Pst3_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Pst2_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Pst1_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Plt3_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Plt2_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Plt1_C = table.Column<bool>(nullable: false),
                    Status_Flagging_LW3_C = table.Column<bool>(nullable: false),
                    Status_Flagging_LW2_C = table.Column<bool>(nullable: false),
                    Status_Flagging_LW1_C = table.Column<bool>(nullable: false),
                    Status_Flagging_Freq_C = table.Column<bool>(nullable: false),
                    Status_Flagging_FLEX_C = table.Column<bool>(nullable: false),
                    Status_Flagging_10mTick_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_U4_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_U3_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_U2_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_U1_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_I4_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_I3_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_I2_C = table.Column<bool>(nullable: false),
                    Status_ADC_Zeroing_I1_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_U4_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_U3_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_U2_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_U1_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_I4_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_I3_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_I2_C = table.Column<bool>(nullable: false),
                    Status_ADC_Clipping_I1_C = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symmetrical_Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    Symmetrical_Components_Zero_φU0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_φI0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_U0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Zero_I0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Unba_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_u2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_u0_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_φU1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_φI1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_U1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Positive_I1_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_φU2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_φI2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_U2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_Negative_I2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_i2_C = table.Column<float>(nullable: false),
                    Symmetrical_Components_i0_C = table.Column<float>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    Inputs_Temperature_avg_Ti_C = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voltages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeasurementPlaceNumberId = table.Column<int>(nullable: true),
                    MeasurementPlaceId = table.Column<Guid>(nullable: true),
                    TimeLocal = table.Column<DateTime>(nullable: false),
                    U_avg_U4_C = table.Column<float>(nullable: false),
                    U_avg_U31_C = table.Column<float>(nullable: false),
                    U_avg_U3_C = table.Column<float>(nullable: false),
                    U_avg_U23_C = table.Column<float>(nullable: false),
                    U_avg_U2_C = table.Column<float>(nullable: false),
                    U_avg_U12_C = table.Column<float>(nullable: false),
                    U_avg_U1_C = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voltages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voltages_MeasurementPlace_MeasurementPlaceId",
                        column: x => x.MeasurementPlaceId,
                        principalTable: "MeasurementPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRole_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Current_MeasurementPlaceId",
                table: "Current",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequency_MeasurementPlaceId",
                table: "Frequency",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Power_MeasurementPlaceId",
                table: "Power",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_MeasurementPlaceId",
                table: "Status",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Symmetrical_Components_MeasurementPlaceId",
                table: "Symmetrical_Components",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MeasurementPlaceId",
                table: "Temperature",
                column: "MeasurementPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UserId",
                table: "UserUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UserRoleId",
                table: "UserUserRole",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Voltages_MeasurementPlaceId",
                table: "Voltages",
                column: "MeasurementPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "SeriesUnit");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Symmetrical_Components");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "UserUserRole");

            migrationBuilder.DropTable(
                name: "Voltages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MeasurementPlace");
        }
    }
}
