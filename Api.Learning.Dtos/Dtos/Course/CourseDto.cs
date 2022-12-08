using Api.Learning.Dtos.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }

        public TeacherDto? Teacher { get; set; }
    }
}
