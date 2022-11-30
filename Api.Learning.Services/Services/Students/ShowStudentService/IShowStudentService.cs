using Api.Learning.Dtos.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.ShowStudentService
{
    public interface IShowStudentService
    {
        StudentDto execute(int Id);
    }
}
