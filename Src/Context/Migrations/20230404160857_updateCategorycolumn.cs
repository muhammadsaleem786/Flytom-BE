using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class updateCategorycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CategoryId",
                table: "Vehicle",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Category_CategoryId",
                table: "Vehicle",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Category_CategoryId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CategoryId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Vehicle");
        }
    }
}
