using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updateContactRealtionshipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contact_EnquiryTypeId",
                table: "Contact",
                column: "EnquiryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_sys_drop_down_value_EnquiryTypeId",
                table: "Contact",
                column: "EnquiryTypeId",
                principalTable: "sys_drop_down_value",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_sys_drop_down_value_EnquiryTypeId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_EnquiryTypeId",
                table: "Contact");
        }
    }
}
