using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Entities.Teacher;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.DataAccess.Repository.Teacher;
using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Dtos.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.ShowTeacherService
{
    public class ShowTeacherService : IShowTeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public ShowTeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }   

        public TeacherDto execute(int Id)
        {
            TeacherEntity result = _teacherRepository.GetById(Id);

            if (result==null)
            {
                return null;
            }

            return new TeacherDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                SecondName = result.SecondName,
                Description = result.Description,
                Email = result.Email,
                Password = result.Password,
                BirthDate = result.BirthDate
            };
        }
    }
}
