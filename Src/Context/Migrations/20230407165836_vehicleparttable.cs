using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class vehicleparttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclePart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    DropDownId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePart_sys_drop_down_value_DropDownId",
                        column: x => x.DropDownId,
                        principalTable: "sys_drop_down_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePart_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_DropDownId",
                table: "VehiclePart",
                column: "DropDownId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_Id",
                table: "VehiclePart",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_Uuid",
                table: "VehiclePart",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_VehicleId",
                table: "VehiclePart",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclePart");
        }
    }
}
