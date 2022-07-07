using Microsoft.EntityFrameworkCore.Migrations;

namespace eHeathApplication.Migrations
{
    public partial class appointmentadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppintmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientModelID = table.Column<int>(type: "int", nullable: false),
                    DoctorModelID = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppintmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_DoctorModels_DoctorModelID",
                        column: x => x.DoctorModelID,
                        principalTable: "DoctorModels",
                        principalColumn: "DoctorModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientModels_PatientModelID",
                        column: x => x.PatientModelID,
                        principalTable: "PatientModels",
                        principalColumn: "PatientModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorModelID",
                table: "Appointments",
                column: "DoctorModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientModelID",
                table: "Appointments",
                column: "PatientModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
