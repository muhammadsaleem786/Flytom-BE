using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class addImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SteeringTyep",
                table: "Vehicle",
                newName: "SteeringType");

            migrationBuilder.CreateTable(
                name: "VehicleImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleImage_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_Id",
                table: "VehicleImage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_Uuid",
                table: "VehicleImage",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImage_VehicleId",
                table: "VehicleImage",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleImage");

            migrationBuilder.RenameColumn(
                name: "SteeringType",
                table: "Vehicle",
                newName: "SteeringTyep");
        }
    }
}
