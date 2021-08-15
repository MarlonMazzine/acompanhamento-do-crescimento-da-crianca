using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.TCC.Context.Migrations
{
    public partial class DoctorEmailUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_doctor_email",
                table: "doctor",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_doctor_email",
                table: "doctor");
        }
    }
}
