using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsVerifiedAccount = table.Column<bool>(type: "bit", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    GanderType = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArealBRA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingTypeId = table.Column<long>(type: "bigint", nullable: false),
                    VolumeCBMM3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_drop_down_mf",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_drop_down_mf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotValidBefore = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLogout = table.Column<bool>(type: "bit", nullable: false),
                    LogoutAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsWeb = table.Column<bool>(type: "bit", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "sys_drop_down_value",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropDownID = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueInNorwegian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependedDropDownID = table.Column<int>(type: "int", nullable: true),
                    DependedDropDownValueID = table.Column<int>(type: "int", nullable: true),
                    SystemGenerated = table.Column<bool>(type: "bit", nullable: true),
                    CompanyID = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_drop_down_value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_drop_down_value_sys_drop_down_mf_DropDownID",
                        column: x => x.DropDownID,
                        principalTable: "sys_drop_down_mf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModel_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehicleModel_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContentManagment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentManagment_sys_drop_down_value_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPacking = table.Column<bool>(type: "bit", nullable: false),
                    MovingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWarehousehotel = table.Column<bool>(type: "bit", nullable: false),
                    Ispiano = table.Column<bool>(type: "bit", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeOfHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRoomId = table.Column<long>(type: "bigint", nullable: false),
                    HouseTypeId = table.Column<long>(type: "bigint", nullable: false),
                    FloorTypeId = table.Column<long>(type: "bigint", nullable: false),
                    garage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingDistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewStreetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewTotalRoomId = table.Column<long>(type: "bigint", nullable: false),
                    NewHouseTypeId = table.Column<long>(type: "bigint", nullable: false),
                    NewSizeOfHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewFloorTypeId = table.Column<long>(type: "bigint", nullable: false),
                    NewParkingDistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Newgarage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_FloorTypeId",
                        column: x => x.FloorTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_HouseTypeId",
                        column: x => x.HouseTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_NewFloorTypeId",
                        column: x => x.NewFloorTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_NewHouseTypeId",
                        column: x => x.NewHouseTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_NewTotalRoomId",
                        column: x => x.NewTotalRoomId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offer_sys_drop_down_value_TotalRoomId",
                        column: x => x.TotalRoomId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    MakesId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleModelsId = table.Column<long>(type: "bigint", nullable: false),
                    FuelTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TankCapacity = table.Column<long>(type: "bigint", nullable: false),
                    NoOfDoor = table.Column<long>(type: "bigint", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<long>(type: "bigint", nullable: false),
                    Width = table.Column<long>(type: "bigint", nullable: false),
                    NoOfSeatId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveWheelType = table.Column<long>(type: "bigint", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeGiven = table.Column<long>(type: "bigint", nullable: true),
                    LoadCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenceType = table.Column<long>(type: "bigint", nullable: false),
                    SequreFeetId = table.Column<long>(type: "bigint", nullable: true),
                    SteeringTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_Makes_MakesId",
                        column: x => x.MakesId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_DriveWheelType",
                        column: x => x.DriveWheelType,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_LicenceType",
                        column: x => x.LicenceType,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_NoOfSeatId",
                        column: x => x.NoOfSeatId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                        column: x => x.SequreFeetId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_sys_drop_down_value_SteeringTypeId",
                        column: x => x.SteeringTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                        column: x => x.VehicleModelsId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BannerDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentManagmentId = table.Column<long>(type: "bigint", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerDetail_ContentManagment_ContentManagmentId",
                        column: x => x.ContentManagmentId,
                        principalTable: "ContentManagment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleImage_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    DropDownId = table.Column<long>(type: "bigint", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePart_sys_drop_down_value_DropDownId",
                        column: x => x.DropDownId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehiclePart_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id",
                table: "Accounts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Uuid",
                table: "Accounts",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Id",
                table: "AppSettings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Uuid",
                table: "AppSettings",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_AccountId",
                table: "AuthTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_Id",
                table: "AuthTokens",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_Uuid",
                table: "AuthTokens",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_ContentManagmentId",
                table: "BannerDetail",
                column: "ContentManagmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_Id",
                table: "BannerDetail",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_Uuid",
                table: "BannerDetail",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_AccountId",
                table: "Category",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "Category",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Uuid",
                table: "Category",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_ContentTypeId",
                table: "ContentManagment",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_Id",
                table: "ContentManagment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_Uuid",
                table: "ContentManagment",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Id",
                table: "Delivery",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Uuid",
                table: "Delivery",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_AccountId",
                table: "Makes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_Id",
                table: "Makes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_Uuid",
                table: "Makes",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_FloorTypeId",
                table: "Offer",
                column: "FloorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_HouseTypeId",
                table: "Offer",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Id",
                table: "Offer",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_NewFloorTypeId",
                table: "Offer",
                column: "NewFloorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_NewHouseTypeId",
                table: "Offer",
                column: "NewHouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_NewTotalRoomId",
                table: "Offer",
                column: "NewTotalRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_TotalRoomId",
                table: "Offer",
                column: "TotalRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Uuid",
                table: "Offer",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_drop_down_mf_Id",
                table: "sys_drop_down_mf",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_drop_down_mf_Uuid",
                table: "sys_drop_down_mf",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_drop_down_value_DropDownID",
                table: "sys_drop_down_value",
                column: "DropDownID");

            migrationBuilder.CreateIndex(
                name: "IX_sys_drop_down_value_Id",
                table: "sys_drop_down_value",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_drop_down_value_Uuid",
                table: "sys_drop_down_value",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_AccountId",
                table: "Vehicle",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CategoryId",
                table: "Vehicle",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriveWheelType",
                table: "Vehicle",
                column: "DriveWheelType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicle",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id",
                table: "Vehicle",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicenceType",
                table: "Vehicle",
                column: "LicenceType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MakesId",
                table: "Vehicle",
                column: "MakesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_NoOfSeatId",
                table: "Vehicle",
                column: "NoOfSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SequreFeetId",
                table: "Vehicle",
                column: "SequreFeetId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SteeringTypeId",
                table: "Vehicle",
                column: "SteeringTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Uuid",
                table: "Vehicle",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelsId",
                table: "Vehicle",
                column: "VehicleModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_Id",
                table: "VehicleImage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_Uuid",
                table: "VehicleImage",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_VehicleId",
                table: "VehicleImage",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_AccountId",
                table: "VehicleModel",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_Id",
                table: "VehicleModel",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_MakeId",
                table: "VehicleModel",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_Uuid",
                table: "VehicleModel",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_DropDownId",
                table: "VehiclePart",
                column: "DropDownId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_Id",
                table: "VehiclePart",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_Uuid",
                table: "VehiclePart",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_VehicleId",
                table: "VehiclePart",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "AuthTokens");

            migrationBuilder.DropTable(
                name: "BannerDetail");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "VehicleImage");

            migrationBuilder.DropTable(
                name: "VehiclePart");

            migrationBuilder.DropTable(
                name: "ContentManagment");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "sys_drop_down_value");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "sys_drop_down_mf");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
