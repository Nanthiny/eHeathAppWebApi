using Microsoft.EntityFrameworkCore.Migrations;

namespace eHeathApplication.Migrations
{
    public partial class docscheduleaddedtomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
