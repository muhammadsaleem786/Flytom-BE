﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Context.Migrations
{
    [DbContext(typeof(FlyttomContext))]
    [Migration("20230404160857_updateCategorycolumn")]
    partial class updateCategorycolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTO.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GanderType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerifiedAccount")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DTO.Models.AppSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("keyword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("AppSettings");
                });

            modelBuilder.Entity("DTO.Models.AuthToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsLogout")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWeb")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LogoutAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NotValidBefore")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("AuthTokens");
                });

            modelBuilder.Entity("DTO.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DTO.Models.Makes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("DTO.Models.Offer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApartmentFloor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DesiredMovingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrentHome")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsFlexible")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInsureMoving")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLift")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovedGarage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovedStorageRoom")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovingHeavyObject")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovingValueableItem")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPackedItem")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStoreObject")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MovingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovingLoad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewHouseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewParkingDistance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewStreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewTotalRoom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoOfPeople")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParkingDistance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeOfHome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalRoom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("DTO.Models.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CarTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriveWheel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FuelTypeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<long>("MakesId")
                        .HasColumnType("bigint");

                    b.Property<long>("NoOfDoor")
                        .HasColumnType("bigint");

                    b.Property<long>("NoOfSeat")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PerDayRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SteeringTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("TankCapacity")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<long>("VehicleModelsId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CarTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("MakesId");

                    b.HasIndex("SteeringTypeId");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.HasIndex("VehicleModelsId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("DTO.Models.VehicleImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<long>("VehicleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleImage");
                });

            modelBuilder.Entity("DTO.Models.VehicleModels", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<long>("MakeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("MakeId");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("DTO.Models.sys_drop_down_mf", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("sys_drop_down_mf");
                });

            modelBuilder.Entity("DTO.Models.sys_drop_down_value", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CompanyID")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DependedDropDownID")
                        .HasColumnType("int");

                    b.Property<int?>("DependedDropDownValueID")
                        .HasColumnType("int");

                    b.Property<long>("DropDownID")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool?>("SystemGenerated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DropDownID");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("sys_drop_down_value");
                });

            modelBuilder.Entity("DTO.Models.AuthToken", b =>
                {
                    b.HasOne("DTO.Models.Account", "Account")
                        .WithMany("AuthTokens")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DTO.Models.Category", b =>
                {
                    b.HasOne("DTO.Models.Account", "Account")
                        .WithMany("Category")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DTO.Models.Makes", b =>
                {
                    b.HasOne("DTO.Models.Account", "Account")
                        .WithMany("Makes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DTO.Models.Vehicle", b =>
                {
                    b.HasOne("DTO.Models.Account", "Account")
                        .WithMany("Vehicle")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.sys_drop_down_value", "sys_drop_down_value1")
                        .WithMany("Vehicle1")
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.Category", "Category")
                        .WithMany("Vehicle")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.sys_drop_down_value", "sys_drop_down_value")
                        .WithMany("Vehicle")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.Makes", "Makes")
                        .WithMany()
                        .HasForeignKey("MakesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.sys_drop_down_value", "sys_drop_down_value2")
                        .WithMany("Vehicle2")
                        .HasForeignKey("SteeringTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.VehicleModels", "VehicleModels")
                        .WithMany()
                        .HasForeignKey("VehicleModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");

                    b.Navigation("Makes");

                    b.Navigation("sys_drop_down_value");

                    b.Navigation("sys_drop_down_value1");

                    b.Navigation("sys_drop_down_value2");

                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("DTO.Models.VehicleImage", b =>
                {
                    b.HasOne("DTO.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleImage")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DTO.Models.VehicleModels", b =>
                {
                    b.HasOne("DTO.Models.Account", "Account")
                        .WithMany("VehicleModels")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.Models.Makes", "Makes")
                        .WithMany("VehicleModels")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Makes");
                });

            modelBuilder.Entity("DTO.Models.sys_drop_down_value", b =>
                {
                    b.HasOne("DTO.Models.sys_drop_down_mf", "sys_drop_down_mf")
                        .WithMany("sys_drop_down_value")
                        .HasForeignKey("DropDownID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sys_drop_down_mf");
                });

            modelBuilder.Entity("DTO.Models.Account", b =>
                {
                    b.Navigation("AuthTokens");

                    b.Navigation("Category");

                    b.Navigation("Makes");

                    b.Navigation("Vehicle");

                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("DTO.Models.Category", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DTO.Models.Makes", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("DTO.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleImage");
                });

            modelBuilder.Entity("DTO.Models.sys_drop_down_mf", b =>
                {
                    b.Navigation("sys_drop_down_value");
                });

            modelBuilder.Entity("DTO.Models.sys_drop_down_value", b =>
                {
                    b.Navigation("Vehicle");

                    b.Navigation("Vehicle1");

                    b.Navigation("Vehicle2");
                });
#pragma warning restore 612, 618
        }
    }
}
