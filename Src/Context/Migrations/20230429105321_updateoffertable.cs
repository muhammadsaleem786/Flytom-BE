using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updateoffertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLift",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "MovingDate",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "TotalRoom",
                table: "Offer",
                newName: "TotalRoomId");

            migrationBuilder.RenameColumn(
                name: "NoOfPeople",
                table: "Offer",
                newName: "NoOfPeopleId");

            migrationBuilder.RenameColumn(
                name: "NewTotalRoom",
                table: "Offer",
                newName: "NewTotalRoomId");

            migrationBuilder.RenameColumn(
                name: "NewHouseType",
                table: "Offer",
                newName: "NewSizeOfHome");

            migrationBuilder.RenameColumn(
                name: "MovingLoad",
                table: "Offer",
                newName: "NewPostalCode");

            migrationBuilder.RenameColumn(
                name: "HouseType",
                table: "Offer",
                newName: "NewHouseTypeId");

            migrationBuilder.RenameColumn(
                name: "ApartmentFloor",
                table: "Offer",
                newName: "NewFloorTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "DesiredMovingDate",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "FlexibleMovingDateId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloorTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovingLoadId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlexibleMovingDateId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "FloorTypeId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "HouseTypeId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "MovingLoadId",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "TotalRoomId",
                table: "Offer",
                newName: "TotalRoom");

            migrationBuilder.RenameColumn(
                name: "NoOfPeopleId",
                table: "Offer",
                newName: "NoOfPeople");

            migrationBuilder.RenameColumn(
                name: "NewTotalRoomId",
                table: "Offer",
                newName: "NewTotalRoom");

            migrationBuilder.RenameColumn(
                name: "NewSizeOfHome",
                table: "Offer",
                newName: "NewHouseType");

            migrationBuilder.RenameColumn(
                name: "NewPostalCode",
                table: "Offer",
                newName: "MovingLoad");

            migrationBuilder.RenameColumn(
                name: "NewHouseTypeId",
                table: "Offer",
                newName: "HouseType");

            migrationBuilder.RenameColumn(
                name: "NewFloorTypeId",
                table: "Offer",
                newName: "ApartmentFloor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DesiredMovingDate",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLift",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MovingDate",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
