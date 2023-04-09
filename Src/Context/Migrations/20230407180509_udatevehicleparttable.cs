using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class udatevehicleparttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "VehiclePart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "VehiclePart");
        }
    }
}
