using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class VehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModel_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<long>(type: "bigint", nullable: false),
                    ModelId = table.Column<long>(type: "bigint", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankCapacity = table.Column<long>(type: "bigint", nullable: false),
                    NoOfDoor = table.Column<long>(type: "bigint", nullable: false),
                    NoOfSeat = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveWheel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerDayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SteeringTyep = table.Column<int>(type: "int", nullable: false),
                    MakesId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleModelsId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Makes_MakesId",
                        column: x => x.MakesId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                        column: x => x.VehicleModelsId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makes_Id",
                table: "Makes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_Uuid",
                table: "Makes",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id",
                table: "Vehicle",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MakesId",
                table: "Vehicle",
                column: "MakesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Uuid",
                table: "Vehicle",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelsId",
                table: "Vehicle",
                column: "VehicleModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_Id",
                table: "VehicleModel",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_MakeId",
                table: "VehicleModel",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_Uuid",
                table: "VehicleModel",
                column: "Uuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
