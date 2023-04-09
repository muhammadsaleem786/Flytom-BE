using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updatenewfieldVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<long>(
                name: "SequreFeetId",
                table: "Vehicle",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RangeGiven",
                table: "Vehicle",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle",
                column: "SequreFeetId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<long>(
                name: "SequreFeetId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RangeGiven",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_sys_drop_down_value_SequreFeetId",
                table: "Vehicle",
                column: "SequreFeetId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
