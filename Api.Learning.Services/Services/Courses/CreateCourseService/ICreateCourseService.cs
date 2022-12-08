using Api.Learning.Dtos.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.CreateCourseService
{
    public interface ICreateCourseService
    {
        CourseDto execute(CreateCourseDto course);

    }
}
