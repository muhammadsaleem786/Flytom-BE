using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class addnewFieldInvehicletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_CarTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CarTypeId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "NoOfSeat",
                table: "Vehicle",
                newName: "SequreFeetId");

            migrationBuilder.RenameColumn(
                name: "DriveWheel",
                table: "Vehicle",
                newName: "LoadCapacity");

            migrationBuilder.RenameColumn(
                name: "CarTypeId",
                table: "Vehicle",
                newName: "RangeGiven");

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DriveWheelType",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LicenceType",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Lift",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NoOfSeatId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriveWheelType",
                table: "Vehicle",
                column: "DriveWheelType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicenceType",
                table: "Vehicle",
                column: "LicenceType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_NoOfSeatId",
                table: "Vehicle",
                column: "NoOfSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SequreFeetId",
                table: "Vehicle",
                column: "SequreFeetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_DriveWheelType",
                table: "Vehicle",
                column: "DriveWheelType",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_LicenceType",
                table: "Vehicle",
                column: "LicenceType",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_NoOfSeatId",
                table: "Vehicle",
                column: "NoOfSeatId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle",
                column: "SequreFeetId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_DriveWheelType",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_LicenceType",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_NoOfSeatId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_DriveWheelType",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_LicenceType",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_NoOfSeatId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_SequreFeetId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "DriveWheelType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "LicenceType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Lift",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "NoOfSeatId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "SequreFeetId",
                table: "Vehicle",
                newName: "NoOfSeat");

            migrationBuilder.RenameColumn(
                name: "RangeGiven",
                table: "Vehicle",
                newName: "CarTypeId");

            migrationBuilder.RenameColumn(
                name: "LoadCapacity",
                table: "Vehicle",
                newName: "DriveWheel");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CarTypeId",
                table: "Vehicle",
                column: "CarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_CarTypeId",
                table: "Vehicle",
                column: "CarTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
