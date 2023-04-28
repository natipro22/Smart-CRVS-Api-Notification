﻿// <auto-generated />
using System;
using AppDiv.CRVS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDiv.CRVS.Infrastructure.Migrations
{
    [DbContext(typeof(CRVSDbContext))]
    [Migration("20230428092538_updateWorkflowStepMOdel")]
    partial class updateWorkflowStepMOdel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppDiv.CRVS.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Otp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("OtpExpiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressNameStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AdminLevel")
                        .HasColumnType("int");

                    b.Property<Guid?>("AreaTypeLookupId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ParentAddressId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StatisticCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AreaTypeLookupId");

                    b.HasIndex("ParentAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Audit.AuditLog", b =>
                {
                    b.Property<Guid>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AuditData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("AuditDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("AuditUserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Enviroment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TablePk")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AuditId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.CertificateTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CertificateType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CertificateTemplates");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.ContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Linkdin")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Lookup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("DescriptionStr")
                        .HasColumnType("longtext");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("StatisticCode")
                        .HasColumnType("longtext");

                    b.Property<string>("ValueStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Lookups");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.PaymentRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventLookupId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PaymentTypeLookupId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("EventLookupId");

                    b.HasIndex("PaymentTypeLookupId");

                    b.ToTable("PaymentRates");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.PersonalInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ContactInfoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("EducationalStatusLookupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstNameStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastNameStr")
                        .HasColumnType("longtext");

                    b.Property<Guid>("MarriageStatusLookupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("MiddleNameStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("NationLookupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("NationalityLookupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PlaceOfBirthLookupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ReligionLookupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SexLookupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TitleLookupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TypeOfWorkLookupId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("EducationalStatusLookupId");

                    b.HasIndex("MarriageStatusLookupId");

                    b.HasIndex("NationLookupId");

                    b.HasIndex("NationalityLookupId");

                    b.HasIndex("PlaceOfBirthLookupId");

                    b.HasIndex("ReligionLookupId");

                    b.HasIndex("SexLookupId");

                    b.HasIndex("TitleLookupId");

                    b.HasIndex("TypeOfWorkLookupId");

                    b.ToTable("PersonalInfos");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("ValueStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("DescreptionStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("step")
                        .HasColumnType("int");

                    b.Property<Guid>("workflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("workflowId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("DescriptionStr")
                        .HasColumnType("longtext");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("RolesStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Workflow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("DescriptionStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("workflowName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("ApplicationUserUserGroup", b =>
                {
                    b.Property<string>("ApplicationUsersId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserGroupsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ApplicationUsersId", "UserGroupsId");

                    b.HasIndex("UserGroupsId");

                    b.ToTable("ApplicationUserUserGroup");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StepUserGroup", b =>
                {
                    b.Property<Guid>("StepsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserGroupsId")
                        .HasColumnType("char(36)");

                    b.HasKey("StepsId", "UserGroupsId");

                    b.HasIndex("UserGroupsId");

                    b.ToTable("StepUserGroup");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.ApplicationUser", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Address", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "AreaTypeLookup")
                        .WithMany("AddressAreaTypeNavigation")
                        .HasForeignKey("AreaTypeLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Address", "ParentAddress")
                        .WithMany("ChildAddresses")
                        .HasForeignKey("ParentAddressId");

                    b.Navigation("AreaTypeLookup");

                    b.Navigation("ParentAddress");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.PaymentRate", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "EventLookup")
                        .WithMany()
                        .HasForeignKey("EventLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "PaymentTypeLookup")
                        .WithMany()
                        .HasForeignKey("PaymentTypeLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("EventLookup");

                    b.Navigation("PaymentTypeLookup");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.PersonalInfo", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Address", "Address")
                        .WithMany("PersonalInfos")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "EducationalStatusLookup")
                        .WithMany("PersonEducationalStatusNavigation")
                        .HasForeignKey("EducationalStatusLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "MarraigeStatusLookup")
                        .WithMany("PersonMarriageStatusNavigation")
                        .HasForeignKey("MarriageStatusLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "NationLookup")
                        .WithMany("PersonNationNavigation")
                        .HasForeignKey("NationLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "NationalityLookup")
                        .WithMany("PersonNationalityNavigation")
                        .HasForeignKey("NationalityLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "PlaceOfBirthLookup")
                        .WithMany("PersonPlaceOfBirthNavigation")
                        .HasForeignKey("PlaceOfBirthLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "ReligionLookup")
                        .WithMany("PersonReligionNavigation")
                        .HasForeignKey("ReligionLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "SexLookup")
                        .WithMany("PersonSexNavigation")
                        .HasForeignKey("SexLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "TitleLookup")
                        .WithMany("PersonTitleNavigation")
                        .HasForeignKey("TitleLookupId");

                    b.HasOne("AppDiv.CRVS.Domain.Entities.Lookup", "TypeOfWorkLookup")
                        .WithMany("PersonTypeOfWorkNavigation")
                        .HasForeignKey("TypeOfWorkLookupId");

                    b.Navigation("Address");

                    b.Navigation("ContactInfo");

                    b.Navigation("EducationalStatusLookup");

                    b.Navigation("MarraigeStatusLookup");

                    b.Navigation("NationLookup");

                    b.Navigation("NationalityLookup");

                    b.Navigation("PlaceOfBirthLookup");

                    b.Navigation("ReligionLookup");

                    b.Navigation("SexLookup");

                    b.Navigation("TitleLookup");

                    b.Navigation("TypeOfWorkLookup");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Step", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Workflow", "workflow")
                        .WithMany("Steps")
                        .HasForeignKey("workflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("workflow");
                });

            modelBuilder.Entity("ApplicationUserUserGroup", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ApplicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StepUserGroup", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Step", null)
                        .WithMany()
                        .HasForeignKey("StepsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDiv.CRVS.Domain.Entities.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Address", b =>
                {
                    b.Navigation("ChildAddresses");

                    b.Navigation("PersonalInfos");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Lookup", b =>
                {
                    b.Navigation("AddressAreaTypeNavigation");

                    b.Navigation("PersonEducationalStatusNavigation");

                    b.Navigation("PersonMarriageStatusNavigation");

                    b.Navigation("PersonNationNavigation");

                    b.Navigation("PersonNationalityNavigation");

                    b.Navigation("PersonPlaceOfBirthNavigation");

                    b.Navigation("PersonReligionNavigation");

                    b.Navigation("PersonSexNavigation");

                    b.Navigation("PersonTitleNavigation");

                    b.Navigation("PersonTypeOfWorkNavigation");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Workflow", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
