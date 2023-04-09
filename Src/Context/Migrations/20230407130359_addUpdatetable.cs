using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class addUpdatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerDayRate",
                table: "Vehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PerDayRate",
                table: "Vehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
