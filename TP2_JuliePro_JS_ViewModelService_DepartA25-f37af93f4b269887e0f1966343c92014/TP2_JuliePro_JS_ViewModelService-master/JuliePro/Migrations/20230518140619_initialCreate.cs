using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuliePro.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CertificationCenter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Disciplines_Parent_Id",
                        column: x => x.Parent_Id,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Discipline_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Disciplines_Discipline_Id",
                        column: x => x.Discipline_Id,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discipline_Id = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trainer_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Disciplines_Discipline_Id",
                        column: x => x.Discipline_Id,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Records_Trainers_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainerCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trainer_Id = table.Column<int>(type: "int", nullable: false),
                    Certification_Id = table.Column<int>(type: "int", nullable: false),
                    DateCertification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerCertifications_Certifications_Certification_Id",
                        column: x => x.Certification_Id,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCertifications_Trainers_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Parent_Id",
                table: "Disciplines",
                column: "Parent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Records_Discipline_Id",
                table: "Records",
                column: "Discipline_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Records_Trainer_Id",
                table: "Records",
                column: "Trainer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCertifications_Certification_Id",
                table: "TrainerCertifications",
                column: "Certification_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCertifications_Trainer_Id",
                table: "TrainerCertifications",
                column: "Trainer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_Discipline_Id",
                table: "Trainers",
                column: "Discipline_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "TrainerCertifications");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
