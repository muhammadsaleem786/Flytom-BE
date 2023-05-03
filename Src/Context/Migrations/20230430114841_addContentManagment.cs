using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class addContentManagment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentManagment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentManagment_sys_drop_down_value_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannerDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentManagmentId = table.Column<long>(type: "bigint", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerDetail_ContentManagment_ContentManagmentId",
                        column: x => x.ContentManagmentId,
                        principalTable: "ContentManagment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_ContentManagmentId",
                table: "BannerDetail",
                column: "ContentManagmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_Id",
                table: "BannerDetail",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerDetail_Uuid",
                table: "BannerDetail",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_ContentTypeId",
                table: "ContentManagment",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_Id",
                table: "ContentManagment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagment_Uuid",
                table: "ContentManagment",
                column: "Uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerDetail");

            migrationBuilder.DropTable(
                name: "ContentManagment");
        }
    }
}
