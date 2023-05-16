using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updatecontacttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contact");

            migrationBuilder.AddColumn<long>(
                name: "EnquiryTypeId",
                table: "Contact",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnquiryTypeId",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
