using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class offerDropdowntableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFlexible = table.Column<bool>(type: "bit", nullable: false),
                    DesiredMovingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPackedItem = table.Column<bool>(type: "bit", nullable: false),
                    IsStoreObject = table.Column<bool>(type: "bit", nullable: false),
                    IsCurrentHome = table.Column<bool>(type: "bit", nullable: false),
                    IsInsureMoving = table.Column<bool>(type: "bit", nullable: false),
                    MovingLoad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPeople = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeOfHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMovedStorageRoom = table.Column<bool>(type: "bit", nullable: false),
                    IsMovedGarage = table.Column<bool>(type: "bit", nullable: false),
                    ParkingDistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewStreetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewTotalRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewHouseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentFloor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLift = table.Column<bool>(type: "bit", nullable: false),
                    NewParkingDistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMovingHeavyObject = table.Column<bool>(type: "bit", nullable: false),
                    IsMovingValueableItem = table.Column<bool>(type: "bit", nullable: false),
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
                name: "sys_drop_down_value",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropDownID = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Id",
                table: "Offer",
                column: "Id",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "sys_drop_down_value");

            migrationBuilder.DropTable(
                name: "sys_drop_down_mf");
        }
    }
}
