using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updateVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SteeringType",
                table: "Vehicle");

            migrationBuilder.AddColumn<long>(
                name: "CarTypeId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FuelTypeId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SteeringTypeId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CarTypeId",
                table: "Vehicle",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicle",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SteeringTypeId",
                table: "Vehicle",
                column: "SteeringTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_CarTypeId",
                table: "Vehicle",
                column: "CarTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_FuelTypeId",
                table: "Vehicle",
                column: "FuelTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SteeringTypeId",
                table: "Vehicle",
                column: "SteeringTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_CarTypeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_FuelTypeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SteeringTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CarTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_SteeringTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SteeringTypeId",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SteeringType",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
