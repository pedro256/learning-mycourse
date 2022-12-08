using Api.Learning.Dtos.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.ListarCourseService
{
    public interface IListarCourser
    {
        List<CourseDto> execute();
    }
}
