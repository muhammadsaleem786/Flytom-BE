using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class relationwithaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "VehicleModel",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Makes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_AccountId",
                table: "VehicleModel",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_AccountId",
                table: "Vehicle",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_AccountId",
                table: "Makes",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makes_Accounts_AccountId",
                table: "Makes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Accounts_AccountId",
                table: "Vehicle",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_Accounts_AccountId",
                table: "VehicleModel",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makes_Accounts_AccountId",
                table: "Makes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Accounts_AccountId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_Accounts_AccountId",
                table: "VehicleModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_AccountId",
                table: "VehicleModel");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_AccountId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Makes_AccountId",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Makes");
        }
    }
}
