using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Dtos.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.CreateStudentService
{
    public class CreateStudentServices : ICreateStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentServices(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        public StudentDto execute(StudentDto student)
        {
            StudentEntity result = _studentRepository.createStudent(new StudentEntity
            {
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                Email = student.Email,
                Password = student.Password,
                Description = student.Description,
                BirthDate = student.BirthDate
            });
            student.Id = result.Id;
            return student;
        }
    }
}
