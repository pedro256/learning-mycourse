using Api.Learning.Dtos.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.ShowCourseService
{
    public interface IShowCourseService
    {
        CourseDto execute(int id);
    }
}
