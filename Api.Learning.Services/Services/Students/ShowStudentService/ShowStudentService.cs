using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Dtos.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.ShowStudentService
{
    public class ShowStudentService : IShowStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public ShowStudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }   

        public StudentDto execute(int Id)
        {
            StudentEntity result = _studentRepository.GetById(Id);

            if (result==null)
            {
                return null;
            }

            return new StudentDto
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
