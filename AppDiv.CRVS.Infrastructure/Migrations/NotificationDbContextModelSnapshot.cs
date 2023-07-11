﻿// <auto-generated />
using System;
using AppDiv.CRVS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDiv.CRVS.Infrastructure.Migrations
{
    [DbContext(typeof(NotificationDbContext))]
    partial class NotificationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.BirthNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<Guid>("DeliveryTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FacilityAddressId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FacilityOwnershipId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IssuedDateEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("IssuerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<Guid>("PlaceOfBirthId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TypeOfBirth")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("BirthNotifications");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.ChildInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("BirthNotificationId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DateOfBirthEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SexLookupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("WeightAtBirth")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BirthNotificationId");

                    b.ToTable("ChildInfos");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.DeathNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CauseOfDeathStr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<Guid>("FacilityAddressId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FacilityOwnershipId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IssuedDateEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("IssuerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<Guid>("PlaceOfDeathId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("DeathNotifications");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.DeathRegistrar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DeathNotificationId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RegistrationDateEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DeathNotificationId")
                        .IsUnique();

                    b.ToTable("DeathRegistrars");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.Deceased", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthDateEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfDeath")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DateOfDeathEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("DeathNotificationId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SexLookupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("TitileLookupId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DeathNotificationId")
                        .IsUnique();

                    b.ToTable("Deceased");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.MotherInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthDateEt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("BirthNotificationId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BirthNotificationId")
                        .IsUnique();

                    b.ToTable("MotherInfo");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.ChildInfo", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Notifications.BirthNotification", "BirthNotification")
                        .WithMany("Childrens")
                        .HasForeignKey("BirthNotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthNotification");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.DeathRegistrar", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Notifications.DeathNotification", "DeathNotification")
                        .WithOne("Registrar")
                        .HasForeignKey("AppDiv.CRVS.Domain.Entities.Notifications.DeathRegistrar", "DeathNotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeathNotification");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.Deceased", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Notifications.DeathNotification", "DeathNotification")
                        .WithOne("Deceased")
                        .HasForeignKey("AppDiv.CRVS.Domain.Entities.Notifications.Deceased", "DeathNotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeathNotification");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.MotherInfo", b =>
                {
                    b.HasOne("AppDiv.CRVS.Domain.Entities.Notifications.BirthNotification", "BirthNotification")
                        .WithOne("Mother")
                        .HasForeignKey("AppDiv.CRVS.Domain.Entities.Notifications.MotherInfo", "BirthNotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthNotification");
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.BirthNotification", b =>
                {
                    b.Navigation("Childrens");

                    b.Navigation("Mother")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDiv.CRVS.Domain.Entities.Notifications.DeathNotification", b =>
                {
                    b.Navigation("Deceased")
                        .IsRequired();

                    b.Navigation("Registrar")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
