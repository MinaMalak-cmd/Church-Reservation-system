using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreWebAPI.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsReservationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masses",
                columns: table => new
                {
                    MassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maxCapacity = table.Column<int>(type: "int", nullable: false),
                    currentSeats = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masses", x => x.MassId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registerationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Masses_MassId",
                        column: x => x.MassId,
                        principalTable: "Masses",
                        principalColumn: "MassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_MassId",
                table: "People",
                column: "MassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Masses");
        }
    }
}
