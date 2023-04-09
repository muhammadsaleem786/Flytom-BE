using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updatenewfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Vehicle");

            migrationBuilder.AddColumn<long>(
                name: "Height",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Width",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
