using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication.TCC.Context.Migrations
{
    public partial class DoctorPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    doctor_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    document = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patient_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    document = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "TIMESTAMP WITHOUT TIME ZONE", nullable: false),
                    weight = table.Column<decimal>(type: "NUMERIC(3,3)", nullable: false),
                    height = table.Column<decimal>(type: "NUMERIC(2,2)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "TIMESTAMP WITHOUT TIME ZONE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "doctor_patient",
                columns: table => new
                {
                    doctor_patient_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    doctor_id = table.Column<long>(nullable: false),
                    patient_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_patient", x => x.doctor_patient_id);
                    table.ForeignKey(
                        name: "FK_doctor_patient_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctor_patient_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctor_patient_patient_id",
                table: "doctor_patient",
                column: "patient_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctor_patient_doctor_id",
                table: "doctor_patient",
                column: "doctor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctor_patient");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "doctor");
        }
    }
}
