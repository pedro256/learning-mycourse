using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Learning.DataAccess.Migrations
{
    public partial class AddFKToCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name:"TeacherId",
                table:"courses",
                nullable:false
                );
            migrationBuilder.AddForeignKey(
                name: "FK_teacher_course",
                table: "courses",
                column: "TeacherId",
                principalTable:"teachers",
                principalColumn:"Id",
                onDelete:ReferentialAction.SetNull
                ) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_course",
                table: "courses"
                ) ;
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table:"courses"
                );
        }
    }
}
