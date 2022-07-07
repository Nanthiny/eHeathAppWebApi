using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHeathApplication.Migrations
{
    public partial class scheduleadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_DoctorModels_DoctorModelID",
                table: "DoctorSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_DoctorModelID",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "DoctorModelID",
                table: "DoctorSchedules");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    DocScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.DocScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_DoctorModels_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorModels",
                        principalColumn: "DoctorModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DoctorID",
                table: "Schedule",
                column: "DoctorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "DoctorModelID",
                table: "DoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorModelID",
                table: "DoctorSchedules",
                column: "DoctorModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_DoctorModels_DoctorModelID",
                table: "DoctorSchedules",
                column: "DoctorModelID",
                principalTable: "DoctorModels",
                principalColumn: "DoctorModelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
