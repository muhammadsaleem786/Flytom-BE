using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updateofferRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TotalRoomId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NoOfPeopleId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NewTotalRoomId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NewHouseTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NewFloorTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MovingLoadId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HouseTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FloorTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FlexibleMovingDateId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_FlexibleMovingDateId",
                table: "Offer",
                column: "FlexibleMovingDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_FloorTypeId",
                table: "Offer",
                column: "FloorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_HouseTypeId",
                table: "Offer",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_MovingLoadId",
                table: "Offer",
                column: "MovingLoadId");

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
                name: "IX_Offer_NoOfPeopleId",
                table: "Offer",
                column: "NoOfPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_TotalRoomId",
                table: "Offer",
                column: "TotalRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_FlexibleMovingDateId",
                table: "Offer",
                column: "FlexibleMovingDateId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_FloorTypeId",
                table: "Offer",
                column: "FloorTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_HouseTypeId",
                table: "Offer",
                column: "HouseTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_MovingLoadId",
                table: "Offer",
                column: "MovingLoadId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewFloorTypeId",
                table: "Offer",
                column: "NewFloorTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewHouseTypeId",
                table: "Offer",
                column: "NewHouseTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewTotalRoomId",
                table: "Offer",
                column: "NewTotalRoomId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_NoOfPeopleId",
                table: "Offer",
                column: "NoOfPeopleId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_sys_drop_down_value_TotalRoomId",
                table: "Offer",
                column: "TotalRoomId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_FlexibleMovingDateId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_FloorTypeId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_HouseTypeId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_MovingLoadId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewFloorTypeId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewHouseTypeId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_NewTotalRoomId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_NoOfPeopleId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_sys_drop_down_value_TotalRoomId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_FlexibleMovingDateId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_FloorTypeId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_HouseTypeId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_MovingLoadId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_NewFloorTypeId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_NewHouseTypeId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_NewTotalRoomId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_NoOfPeopleId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_TotalRoomId",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "TotalRoomId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "NoOfPeopleId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "NewTotalRoomId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "NewHouseTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "NewFloorTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "MovingLoadId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "HouseTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "FloorTypeId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "FlexibleMovingDateId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
