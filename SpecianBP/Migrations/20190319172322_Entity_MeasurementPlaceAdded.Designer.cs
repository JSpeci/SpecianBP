﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpecianBP.Db;

namespace SpecianBP.Migrations
{
    [DbContext(typeof(DbService))]
    [Migration("20190319172322_Entity_MeasurementPlaceAdded")]
    partial class Entity_MeasurementPlaceAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpecianBP.Entities.Current", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("I_avg_3I_C");

                    b.Property<float>("I_avg_I1_C");

                    b.Property<float>("I_avg_I2_C");

                    b.Property<float>("I_avg_I3_C");

                    b.Property<float>("I_avg_I4_C");

                    b.Property<float>("I_avg_INc_C");

                    b.Property<float>("I_avg_IPEc_C");

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<DateTime>("TimeLocal");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Current");
                });

            modelBuilder.Entity("SpecianBP.Entities.Frequency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cos_3Cos_C");

                    b.Property<float>("Cos_Cos1_C");

                    b.Property<float>("Cos_Cos2_C");

                    b.Property<float>("Cos_Cos3_C");

                    b.Property<float>("Cos_Cos4_C");

                    b.Property<float>("D_avg_3D_C");

                    b.Property<float>("D_avg_D1_C");

                    b.Property<float>("D_avg_D2_C");

                    b.Property<float>("D_avg_D3_C");

                    b.Property<float>("D_avg_D4_C");

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<DateTime>("TimeLocal");

                    b.Property<float>("f_avg_f_C");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Frequency");
                });

            modelBuilder.Entity("SpecianBP.Entities.MeasurementPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("DisplayName");

                    b.Property<string>("FileName");

                    b.Property<int>("NumberId");

                    b.HasKey("Id");

                    b.ToTable("MeasurementPlace");
                });

            modelBuilder.Entity("SpecianBP.Entities.Power", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<float>("PF_3PF_C");

                    b.Property<float>("PF_PF1_C");

                    b.Property<float>("PF_PF2_C");

                    b.Property<float>("PF_PF3_C");

                    b.Property<float>("PF_PF4_C");

                    b.Property<float>("P_avg_3P_C");

                    b.Property<float>("P_avg_3Pminus_C");

                    b.Property<float>("P_avg_3Pplus_C");

                    b.Property<float>("P_avg_P1_C");

                    b.Property<float>("P_avg_P1minus_C");

                    b.Property<float>("P_avg_P1plus_C");

                    b.Property<float>("P_avg_P2_C");

                    b.Property<float>("P_avg_P2minus_C");

                    b.Property<float>("P_avg_P2plus_C");

                    b.Property<float>("P_avg_P3_C");

                    b.Property<float>("P_avg_P3minus_C");

                    b.Property<float>("P_avg_P3plus_C");

                    b.Property<float>("P_avg_P4_C");

                    b.Property<float>("P_avg_P4minus_C");

                    b.Property<float>("P_avg_P4plus_C");

                    b.Property<float>("Q_avg_3Q_C");

                    b.Property<float>("Q_avg_3Qminus_C");

                    b.Property<float>("Q_avg_3Qplus_C");

                    b.Property<float>("Q_avg_Q1_C");

                    b.Property<float>("Q_avg_Q1minus_C");

                    b.Property<float>("Q_avg_Q1plus_C");

                    b.Property<float>("Q_avg_Q2_C");

                    b.Property<float>("Q_avg_Q2minus_C");

                    b.Property<float>("Q_avg_Q2plus_C");

                    b.Property<float>("Q_avg_Q3_C");

                    b.Property<float>("Q_avg_Q3minus_C");

                    b.Property<float>("Q_avg_Q3plus_C");

                    b.Property<float>("Q_avg_Q4_C");

                    b.Property<float>("Q_avg_Q4minus_C");

                    b.Property<float>("Q_avg_Q4plus_C");

                    b.Property<float>("S_avg_3S_C");

                    b.Property<float>("S_avg_S1_C");

                    b.Property<float>("S_avg_S2_C");

                    b.Property<float>("S_avg_S3_C");

                    b.Property<float>("S_avg_S4_C");

                    b.Property<DateTime>("TimeLocal");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Power");
                });

            modelBuilder.Entity("SpecianBP.Entities.SeriesUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SeriesName");

                    b.Property<string>("UnitName");

                    b.HasKey("Id");

                    b.ToTable("SeriesUnit");
                });

            modelBuilder.Entity("SpecianBP.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<bool>("Status_ADC_Clipping_I1_C");

                    b.Property<bool>("Status_ADC_Clipping_I2_C");

                    b.Property<bool>("Status_ADC_Clipping_I3_C");

                    b.Property<bool>("Status_ADC_Clipping_I4_C");

                    b.Property<bool>("Status_ADC_Clipping_U1_C");

                    b.Property<bool>("Status_ADC_Clipping_U2_C");

                    b.Property<bool>("Status_ADC_Clipping_U3_C");

                    b.Property<bool>("Status_ADC_Clipping_U4_C");

                    b.Property<bool>("Status_ADC_Zeroing_I1_C");

                    b.Property<bool>("Status_ADC_Zeroing_I2_C");

                    b.Property<bool>("Status_ADC_Zeroing_I3_C");

                    b.Property<bool>("Status_ADC_Zeroing_I4_C");

                    b.Property<bool>("Status_ADC_Zeroing_U1_C");

                    b.Property<bool>("Status_ADC_Zeroing_U2_C");

                    b.Property<bool>("Status_ADC_Zeroing_U3_C");

                    b.Property<bool>("Status_ADC_Zeroing_U4_C");

                    b.Property<bool>("Status_Flagging_10mTick_C");

                    b.Property<bool>("Status_Flagging_FLEX_C");

                    b.Property<bool>("Status_Flagging_Freq_C");

                    b.Property<bool>("Status_Flagging_LW1_C");

                    b.Property<bool>("Status_Flagging_LW2_C");

                    b.Property<bool>("Status_Flagging_LW3_C");

                    b.Property<bool>("Status_Flagging_Plt1_C");

                    b.Property<bool>("Status_Flagging_Plt2_C");

                    b.Property<bool>("Status_Flagging_Plt3_C");

                    b.Property<bool>("Status_Flagging_Pst1_C");

                    b.Property<bool>("Status_Flagging_Pst2_C");

                    b.Property<bool>("Status_Flagging_Pst3_C");

                    b.Property<bool>("Status_Flagging_Time_C");

                    b.Property<bool>("Status_Flagging_UIP1_C");

                    b.Property<bool>("Status_Flagging_UIP2_C");

                    b.Property<bool>("Status_Flagging_UIP3_C");

                    b.Property<string>("Status_Flags_C");

                    b.Property<string>("Status_Flow_C");

                    b.Property<DateTime>("TimeLocal");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SpecianBP.Entities.Symmetrical_Components", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<float>("Symmetrical_Components_Negative_I2_C");

                    b.Property<float>("Symmetrical_Components_Negative_U2_C");

                    b.Property<float>("Symmetrical_Components_Negative_φI2_C");

                    b.Property<float>("Symmetrical_Components_Negative_φU2_C");

                    b.Property<float>("Symmetrical_Components_Positive_I1_C");

                    b.Property<float>("Symmetrical_Components_Positive_U1_C");

                    b.Property<float>("Symmetrical_Components_Positive_φI1_C");

                    b.Property<float>("Symmetrical_Components_Positive_φU1_C");

                    b.Property<float>("Symmetrical_Components_Unba_C");

                    b.Property<float>("Symmetrical_Components_Zero_I0_C");

                    b.Property<float>("Symmetrical_Components_Zero_U0_C");

                    b.Property<float>("Symmetrical_Components_Zero_φI0_C");

                    b.Property<float>("Symmetrical_Components_Zero_φU0_C");

                    b.Property<float>("Symmetrical_Components_i0_C");

                    b.Property<float>("Symmetrical_Components_i2_C");

                    b.Property<float>("Symmetrical_Components_u0_C");

                    b.Property<float>("Symmetrical_Components_u2_C");

                    b.Property<DateTime>("TimeLocal");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Symmetrical_Components");
                });

            modelBuilder.Entity("SpecianBP.Entities.Temperature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Inputs_Temperature_avg_Ti_C");

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<DateTime>("TimeLocal");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("SpecianBP.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SpecianBP.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GrantsSerialized");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SpecianBP.Entities.UserUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("UserId");

                    b.Property<Guid>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserUserRole");
                });

            modelBuilder.Entity("SpecianBP.Entities.Voltage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MeasurementPlaceId");

                    b.Property<int?>("MeasurementPlaceNumberId");

                    b.Property<DateTime>("TimeLocal");

                    b.Property<float>("U_avg_U12_C");

                    b.Property<float>("U_avg_U1_C");

                    b.Property<float>("U_avg_U23_C");

                    b.Property<float>("U_avg_U2_C");

                    b.Property<float>("U_avg_U31_C");

                    b.Property<float>("U_avg_U3_C");

                    b.Property<float>("U_avg_U4_C");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPlaceId");

                    b.ToTable("Voltages");
                });

            modelBuilder.Entity("SpecianBP.Entities.Current", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.Frequency", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.Power", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.Status", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.Symmetrical_Components", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.Temperature", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });

            modelBuilder.Entity("SpecianBP.Entities.UserUserRole", b =>
                {
                    b.HasOne("SpecianBP.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecianBP.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpecianBP.Entities.Voltage", b =>
                {
                    b.HasOne("SpecianBP.Entities.MeasurementPlace", "MeasurementPlace")
                        .WithMany()
                        .HasForeignKey("MeasurementPlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
