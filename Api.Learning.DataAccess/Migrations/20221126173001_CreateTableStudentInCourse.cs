using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Api.Learning.DataAccess.Migrations
{
    public partial class CreateTableStudentInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name:"student-in-course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdStudent = table.Column<int>(nullable: false),
                    IdCourse = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student-in-course", x => x.Id);
                    table.ForeignKey(
                        name:"FK_student_id",
                        column :x => x.IdStudent,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name:"FK_course_id",
                        column: x=>x.IdCourse,
                        principalTable:"courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                        );
                }
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "student-in-course");
        }
    }
}
