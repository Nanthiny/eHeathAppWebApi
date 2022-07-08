using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHeathApplication.Migrations
{
    public partial class onlineappointmentadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineAppointments",
                columns: table => new
                {
                    OnlineAppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStatus = table.Column<bool>(type: "bit", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineAppointments", x => x.OnlineAppointmentID);
                    table.ForeignKey(
                        name: "FK_OnlineAppointments_DoctorModels_DoctorModelID",
                        column: x => x.DoctorModelID,
                        principalTable: "DoctorModels",
                        principalColumn: "DoctorModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineAppointments_DoctorModelID",
                table: "OnlineAppointments",
                column: "DoctorModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineAppointments");
        }
    }
}
