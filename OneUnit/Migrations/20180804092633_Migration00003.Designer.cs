﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneUnit.Data;

namespace OneUnit.Migrations
{
    [DbContext(typeof(OneUnitContext))]
    [Migration("20180804092633_Migration00003")]
    partial class Migration00003
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OneUnit.Areas.Admin.Data.Entities.StoreUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ColumnNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ColumnNumber","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Confirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Confirmation","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ControlParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BottomLimit");

                    b.Property<int>("ControlParameterTypeId");

                    b.Property<int>("ControlToolsId");

                    b.Property<int>("DegreeOfImportanceId");

                    b.Property<string>("Name");

                    b.Property<int>("ProcessNameId");

                    b.Property<int>("ProcessTypeId");

                    b.Property<int>("RActionId");

                    b.Property<int>("RControlId");

                    b.Property<int>("SampleValueId");

                    b.Property<int>("SamplingFrequencyId");

                    b.Property<int>("SamplingLocationId");

                    b.Property<int>("StandardAId");

                    b.Property<int>("StandardPId");

                    b.Property<int>("TestValueId");

                    b.Property<int>("UnitOfMeasurementId");

                    b.Property<decimal>("UpperLimit");

                    b.HasKey("Id");

                    b.HasIndex("ControlParameterTypeId");

                    b.HasIndex("ControlToolsId");

                    b.HasIndex("DegreeOfImportanceId");

                    b.HasIndex("ProcessNameId");

                    b.HasIndex("ProcessTypeId");

                    b.HasIndex("RActionId");

                    b.HasIndex("RControlId");

                    b.HasIndex("SampleValueId");

                    b.HasIndex("SamplingFrequencyId");

                    b.HasIndex("SamplingLocationId");

                    b.HasIndex("StandardAId");

                    b.HasIndex("StandardPId");

                    b.HasIndex("TestValueId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.ToTable("ControlParameter","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ControlParameterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ControlParameterType","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ControlTools", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ControlTools","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Day", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Day","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.DegreeOfImportance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DegreeOfImportance","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Hour", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Hour","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Month", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Month","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.OrganizationalUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OrganizationalUnit","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ProcessName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProcessName","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ProcessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProcessType","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Production","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QParameterStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("QParameterStatus","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QualityControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("DayId");

                    b.Property<byte>("HourId");

                    b.Property<byte>("MonthId");

                    b.Property<byte>("ShiftId");

                    b.Property<byte>("YearId");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("HourId");

                    b.HasIndex("MonthId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("YearId");

                    b.ToTable("QualityControl","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QualityDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColumnNumberId");

                    b.Property<int>("ConfirmationId");

                    b.Property<int>("ControlParameterId");

                    b.Property<string>("ControllerUserId");

                    b.Property<string>("DateQD");

                    b.Property<string>("DateStorageTransfer");

                    b.Property<string>("DateTankDrain");

                    b.Property<string>("DateTankFilling");

                    b.Property<string>("Description");

                    b.Property<decimal>("LevelTank");

                    b.Property<int>("ProcessNameId");

                    b.Property<int>("ProductionId");

                    b.Property<int>("QParameterStatusId");

                    b.Property<string>("SamplerId");

                    b.Property<int>("SamplingLocationId");

                    b.Property<byte>("ShiftId");

                    b.Property<int>("StorageId");

                    b.Property<int>("TankId");

                    b.Property<string>("TesterId");

                    b.Property<decimal>("ValueLimit");

                    b.HasKey("Id");

                    b.HasIndex("ColumnNumberId");

                    b.HasIndex("ConfirmationId");

                    b.HasIndex("ControlParameterId");

                    b.HasIndex("ControllerUserId");

                    b.HasIndex("ProcessNameId");

                    b.HasIndex("ProductionId");

                    b.HasIndex("QParameterStatusId");

                    b.HasIndex("SamplerId");

                    b.HasIndex("SamplingLocationId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("StorageId");

                    b.HasIndex("TankId");

                    b.HasIndex("TesterId");

                    b.ToTable("QualityDesign","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.SampleValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SampleValue","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.SamplingFrequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SamplingFrequency","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.SamplingLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SamplingLocation","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Shift", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Shift","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.StandardA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StandardA","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.StandardP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StandardP","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Storage","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Tank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tank","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.TestValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TestValue","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.UnitOfMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasurement","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Year", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Year","QC");
                });

            modelBuilder.Entity("OneUnit.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("UserId");

                    b.Property<int>("ggg");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OneUnit.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("OneUnit.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtDating");

                    b.Property<string>("ArtDescription");

                    b.Property<string>("ArtId");

                    b.Property<string>("Artist");

                    b.Property<DateTime>("ArtistBirthDate");

                    b.Property<DateTime>("ArtistDeathDate");

                    b.Property<string>("ArtistNationality");

                    b.Property<string>("Category");

                    b.Property<decimal>("Price");

                    b.Property<string>("Size");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ControlParameter", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ControlParameterType", "ControlParameterType")
                        .WithMany("ControlParameters")
                        .HasForeignKey("ControlParameterTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ControlTools", "ControlTools")
                        .WithMany("ControlParameters")
                        .HasForeignKey("ControlToolsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.DegreeOfImportance", "DegreeOfImportance")
                        .WithMany("ControlParameters")
                        .HasForeignKey("DegreeOfImportanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ProcessName", "ProcessName")
                        .WithMany("ControlParameters")
                        .HasForeignKey("ProcessNameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ProcessType", "ProcessType")
                        .WithMany("ControlParameters")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.OrganizationalUnit", "RAction")
                        .WithMany("ControlParameterRActions")
                        .HasForeignKey("RActionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.OrganizationalUnit", "RControl")
                        .WithMany("ControlParameterRControls")
                        .HasForeignKey("RControlId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SampleValue", "SampleValue")
                        .WithMany("ControlParameters")
                        .HasForeignKey("SampleValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SamplingFrequency", "SamplingFrequency")
                        .WithMany("ControlParameters")
                        .HasForeignKey("SamplingFrequencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SamplingLocation", "SamplingLocation")
                        .WithMany("ControlParameters")
                        .HasForeignKey("SamplingLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.StandardA", "StandardA")
                        .WithMany("ControlParameters")
                        .HasForeignKey("StandardAId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.StandardP", "StandardP")
                        .WithMany("ControlParameters")
                        .HasForeignKey("StandardPId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.TestValue", "TestValue")
                        .WithMany("ControlParameters")
                        .HasForeignKey("TestValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.UnitOfMeasurement", "UnitOfMeasurement")
                        .WithMany("ControlParameters")
                        .HasForeignKey("UnitOfMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QualityControl", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Day", "Day")
                        .WithMany("QualityControls")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Hour", "Hour")
                        .WithMany("QualityControls")
                        .HasForeignKey("HourId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Month", "Month")
                        .WithMany("QualityControls")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Shift", "Shift")
                        .WithMany("QualityControls")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Year", "Year")
                        .WithMany("QualityControls")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QualityDesign", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ColumnNumber", "ColumnNumber")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ColumnNumberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Confirmation", "Confirmation")
                        .WithMany()
                        .HasForeignKey("ConfirmationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ControlParameter", "ControlParameter")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ControlParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser", "ControllerUser")
                        .WithMany()
                        .HasForeignKey("ControllerUserId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ProcessName", "ProcessName")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ProcessNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Production", "Production")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.QParameterStatus", "QParameterStatus")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("QParameterStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser", "Sampler")
                        .WithMany()
                        .HasForeignKey("SamplerId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SamplingLocation", "SamplingLocation")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("SamplingLocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Storage", "Storage")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Tank", "Tank")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser", "Tester")
                        .WithMany()
                        .HasForeignKey("TesterId");
                });

            modelBuilder.Entity("OneUnit.Data.Entities.Order", b =>
                {
                    b.HasOne("OneUnit.Areas.Admin.Data.Entities.StoreUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OneUnit.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("OneUnit.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OneUnit.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
