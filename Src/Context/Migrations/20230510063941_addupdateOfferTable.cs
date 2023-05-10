using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class addupdateOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValueInNorwegian",
                table: "sys_drop_down_value",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewlift",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Islift",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "NewWhichFloorTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WhichFloorTypeId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueInNorwegian",
                table: "sys_drop_down_value");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "IsNewlift",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Islift",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NewWhichFloorTypeId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "WhichFloorTypeId",
                table: "Offer");
        }
    }
}
