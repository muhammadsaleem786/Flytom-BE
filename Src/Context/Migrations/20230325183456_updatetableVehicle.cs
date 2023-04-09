using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updatetableVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Makes_MakesId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<long>(
                name: "VehicleModelsId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MakesId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Makes_MakesId",
                table: "Vehicle",
                column: "MakesId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                table: "Vehicle",
                column: "VehicleModelsId",
                principalTable: "VehicleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Makes_MakesId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<long>(
                name: "VehicleModelsId",
                table: "Vehicle",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MakesId",
                table: "Vehicle",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "MakeId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModelId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Makes_MakesId",
                table: "Vehicle",
                column: "MakesId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                table: "Vehicle",
                column: "VehicleModelsId",
                principalTable: "VehicleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
