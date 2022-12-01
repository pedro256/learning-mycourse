using Api.Learning.Dtos.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.ListTeachersService
{
    public interface IListTeacherService
    {
        List<TeacherDto> execute();
    }
}
