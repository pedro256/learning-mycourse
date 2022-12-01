using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Dtos.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.ShowTeacherService
{
    public interface IShowTeacherService
    {
        TeacherDto execute(int Id);
    }
}
