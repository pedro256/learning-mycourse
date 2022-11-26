using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Learning.DataAccess.Migrations
{
    public partial class AddFKToContentToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name:"courseId",
                table: "content-course",
                nullable: false
                );
            migrationBuilder.AddForeignKey(
                name:"FK_course_content",
                table: "content-course",
                column: "courseId",
                principalTable:"courses",
                principalColumn:"Id",
                onDelete:ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_course_content",table: "content-course");
            migrationBuilder.DropColumn(name: "courseId", table: "content-course");
        }
    }
}
