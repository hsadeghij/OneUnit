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
    [Migration("20190531092844_Migration00039")]
    partial class Migration00039
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

                    b.Property<string>("StoreUserId1");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StoreUserId1");

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

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Company","QC");
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

                    b.Property<int?>("CompanyId");

                    b.Property<int>("DegreeOfImportanceId");

                    b.Property<string>("Name");

                    b.Property<int?>("OrganizationalUnitId");

                    b.Property<int>("ProcessNameId");

                    b.Property<int>("ProcessTypeId");

                    b.Property<int>("RActionId");

                    b.Property<int>("SampleValueId");

                    b.Property<int>("SamplingFrequencyId");

                    b.Property<int>("SamplingLocationId");

                    b.Property<int>("TestValueId");

                    b.Property<int>("UnitOfMeasurementId");

                    b.Property<decimal>("UpperLimit");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DegreeOfImportanceId");

                    b.HasIndex("OrganizationalUnitId");

                    b.HasIndex("ProcessNameId");

                    b.HasIndex("ProcessTypeId");

                    b.HasIndex("RActionId");

                    b.HasIndex("SampleValueId");

                    b.HasIndex("SamplingLocationId");

                    b.HasIndex("TestValueId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.ToTable("ControlParameter","QC");
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

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.HasT", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HasT","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Hour", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Hour","QC");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.Minute", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Minute","QC");
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

                    b.Property<int>("CompanyId");

                    b.Property<byte?>("HasTId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("HasTId");

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

                    b.Property<int?>("ConfirmationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmationId");

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

                    b.Property<int?>("CompanyId");

                    b.Property<int>("ConfirmationId");

                    b.Property<int>("ControlParameterId");

                    b.Property<string>("DateQD");

                    b.Property<string>("Description");

                    b.Property<int>("ProcessNameId");

                    b.Property<int?>("QParameterStatusId");

                    b.Property<string>("RegistrationTime");

                    b.Property<int?>("SamplingLocationId");

                    b.Property<byte>("ShiftId");

                    b.Property<int?>("StorageId");

                    b.Property<string>("TransferTimeToStorage");

                    b.Property<decimal?>("ValueLimit");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ConfirmationId");

                    b.HasIndex("ControlParameterId");

                    b.HasIndex("ProcessNameId");

                    b.HasIndex("QParameterStatusId");

                    b.HasIndex("SamplingLocationId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("StorageId");

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

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.SamplingLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Name");

                    b.Property<int?>("ProcessNameId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProcessNameId");

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

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image");

                    b.Property<int?>("ProjectPlanId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPlanId");

                    b.ToTable("Attachment","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.CurrentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CurrentState","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("FullName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Mobile");

                    b.Property<string>("NationalCode");

                    b.Property<string>("PersonalCode");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Person","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Post","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Project","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.ProjectMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PersonId");

                    b.Property<int?>("ProjectPlanId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProjectPlanId");

                    b.ToTable("ProjectMember","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.ProjectPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity");

                    b.Property<string>("DateReg");

                    b.Property<string>("Description");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("WorkTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("ProjectPlan","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Rating", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Rating","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.TransitInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurrentStateId");

                    b.Property<string>("DateReg");

                    b.Property<int?>("PersonId");

                    b.Property<byte>("RatingId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RatingId");

                    b.ToTable("TransitInfo","Tran");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkType","Tran");
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
                        .WithMany("Workers")
                        .HasForeignKey("StoreUserId1");

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
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Company", "Company")
                        .WithMany("ControlParameters")
                        .HasForeignKey("CompanyId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.DegreeOfImportance", "DegreeOfImportance")
                        .WithMany("ControlParameters")
                        .HasForeignKey("DegreeOfImportanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.OrganizationalUnit")
                        .WithMany("ControlParameterRControls")
                        .HasForeignKey("OrganizationalUnitId");

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

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SampleValue", "SampleValue")
                        .WithMany("ControlParameters")
                        .HasForeignKey("SampleValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SamplingLocation", "SamplingLocation")
                        .WithMany("ControlParameters")
                        .HasForeignKey("SamplingLocationId")
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

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.ProcessName", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Company", "Company")
                        .WithMany("ProcessNames")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.HasT", "HasT")
                        .WithMany("ProcessNames")
                        .HasForeignKey("HasTId");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.QParameterStatus", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Confirmation", "Confirmation")
                        .WithMany("QParameterStatuss")
                        .HasForeignKey("ConfirmationId");
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
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Company", "Company")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("CompanyId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Confirmation", "Confirmation")
                        .WithMany()
                        .HasForeignKey("ConfirmationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ControlParameter", "ControlParameter")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ControlParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ProcessName", "ProcessName")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("ProcessNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.QParameterStatus", "QParameterStatus")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("QParameterStatusId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.SamplingLocation", "SamplingLocation")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("SamplingLocationId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Storage", "Storage")
                        .WithMany("QualityDesigns")
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("OneUnit.Areas.QC.Data.Entities.SamplingLocation", b =>
                {
                    b.HasOne("OneUnit.Areas.QC.Data.Entities.Company", "Company")
                        .WithMany("SamplingLocations")
                        .HasForeignKey("CompanyId");

                    b.HasOne("OneUnit.Areas.QC.Data.Entities.ProcessName", "ProcessName")
                        .WithMany("SamplingLocations")
                        .HasForeignKey("ProcessNameId");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Attachment", b =>
                {
                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.ProjectPlan", "ProjectPlan")
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectPlanId");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.Person", b =>
                {
                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Post", "Post")
                        .WithMany("Persons")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.ProjectMember", b =>
                {
                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Person", "Person")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("PersonId");

                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.ProjectPlan", "ProjectPlan")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("ProjectPlanId");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.ProjectPlan", b =>
                {
                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Person", "Person")
                        .WithMany("ProjectPlans")
                        .HasForeignKey("PersonId");

                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Project", "Project")
                        .WithMany("ProjectPlans")
                        .HasForeignKey("ProjectId");

                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.WorkType", "WorkType")
                        .WithMany("ProjectPlans")
                        .HasForeignKey("WorkTypeId");
                });

            modelBuilder.Entity("OneUnit.Areas.Transit.Data.Entities.TransitInfo", b =>
                {
                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.CurrentState", "CurrentState")
                        .WithMany("TransitInfos")
                        .HasForeignKey("CurrentStateId");

                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Person", "Person")
                        .WithMany("TransitInfos")
                        .HasForeignKey("PersonId");

                    b.HasOne("OneUnit.Areas.Transit.Data.Entities.Rating", "Rating")
                        .WithMany("TransitInfos")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade);
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
